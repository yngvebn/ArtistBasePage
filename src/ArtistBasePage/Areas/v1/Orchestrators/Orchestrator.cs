using Infrastructure.Commands;

namespace ArtistBasePage.Areas.v1.Orchestrators
{
    public class Orchestrator
    {
        protected CommandResult Execute(Command command)
        {
            return MvcApplication.CommandExecutor.ExecuteCommand(command);

        }
    }
}