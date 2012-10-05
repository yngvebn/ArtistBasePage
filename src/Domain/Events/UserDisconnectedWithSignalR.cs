using Infrastructure.DomainEvents;

namespace Domain.Events
{
    public class UserDisconnectedWithSignalR : IDomainEvent
    {
        public string ConnectionId { get; set; }
    }
}