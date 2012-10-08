using System.Threading.Tasks;
using Ninject;

namespace Infrastructure.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IKernel _kernel;

        public CommandExecutor(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CommandResult ExecuteCommand(Command command)
        {
            dynamic handler = FindHandlerForCommand(command);

            try
            {
                handler.Handle(command as dynamic);
                return CommandResult.Executed("Command executed successfully");
            }
            finally
            {
                _kernel.Release(handler);
            }
        }

        public Task<CommandResult> ExecuteCommandAsync(Command command)
        {
            dynamic handler = FindHandlerForCommand(command);

            try
            {
                var task =Task.Factory.StartNew(() => 
                    {
                        handler.Handle(command as dynamic);
                        return CommandResult.Executed("Command executed successfully");
                    });
                
                return task;
            }
            finally
            {
                _kernel.Release(handler);
            }
        }

        private object FindHandlerForCommand(Command command)
        {
            var handlerType = typeof(IHandleCommand<>).MakeGenericType(command.GetType());
            dynamic handler = _kernel.Get(handlerType);
            return handler;
        }
    }
}