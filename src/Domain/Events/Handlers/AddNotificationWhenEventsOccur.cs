using Infrastructure.DomainEvents;

namespace Domain.Events.Handlers
{
    public class AddNotificationWhenEventsOccur:
        IHandleDomainEvent<LastFmInfoWasUpdated>
    {
        public void Handle(LastFmInfoWasUpdated domainEvent)
        {
            domainEvent.Info.AssociatedArtist.AddNotification(new ConnectToLastFmNotification(domainEvent.Info));
        }
    }
}