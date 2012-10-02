using Infrastructure.Commands;

namespace Domain.Commands
{
    public class UserDisconnectedWithSignalR : Command
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
    }
}