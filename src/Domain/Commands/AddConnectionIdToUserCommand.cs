using Infrastructure.Commands;

namespace Domain.Commands
{
    public class AddConnectionIdToUserCommand: Command
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; } 
    }

    public class RemoveConnectionIdToUserCommand : Command
    {
        public string ConnectionId { get; set; }
    }
}