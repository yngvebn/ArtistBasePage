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

        private object FindHandlerForCommand(Command command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _kernel.Get(handlerType);
            return handler;
        }
    }
}