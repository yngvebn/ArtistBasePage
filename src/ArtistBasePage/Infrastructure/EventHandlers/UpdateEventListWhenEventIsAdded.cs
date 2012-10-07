using ArtistBasePage.Areas.Admin.Hubs;
using Domain.Events;
using Infrastructure.DomainEvents;
using SignalR;

namespace ArtistBasePage.Infrastructure.EventHandlers
{
    public class UpdateEventListWhenEventIsAdded: IHandleDomainEvent<EventWasAdded>
    {
        public void Handle(EventWasAdded domainEvent)
        {
            GlobalHost.ConnectionManager.GetHubContext<EventsHub>().Clients.EventWasAdded();
        }
    }
}