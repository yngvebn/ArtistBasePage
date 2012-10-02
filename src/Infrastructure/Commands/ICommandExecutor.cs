using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public interface ICommandExecutor
    {
        CommandResult ExecuteCommand(Command command);
        Task<CommandResult> ExecuteCommandAsync(Command command);
    }
}