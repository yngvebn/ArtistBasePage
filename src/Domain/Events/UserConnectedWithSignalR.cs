using Infrastructure.DomainEvents;

namespace Domain.Events
{
    public class UserConnectedWithSignalR : IDomainEvent
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
    }
}