using Infrastructure.DomainEvents;

namespace Domain.Events
{
    public class NotificationAdded: IDomainEvent
    {
        public Artist Artist { get; set; }

        public Notification LastNotification { get; set; }
    }
}