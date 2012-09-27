namespace Infrastructure.Commands
{
    public interface ICommandExecutor
    {
        CommandResult ExecuteCommand(Command command);
    }
}