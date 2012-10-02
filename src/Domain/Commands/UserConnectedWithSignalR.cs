using Infrastructure.Commands;

namespace Domain.Commands
{
    public class UserConnectedWithSignalR : Command
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
    }
}