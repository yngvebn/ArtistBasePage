using System;
using ArtistBasePage.Areas.Admin.Hubs;
using Domain.Events;
using Infrastructure.DomainEvents;
using SignalR;

namespace ArtistBasePage.Infrastructure.EventHandlers
{
    public class DisplayLastFmOptionsWhenUserIsConnected: IHandleDomainEvent<ArtistWasConnectedToLastFm>
    {
        public void Handle(ArtistWasConnectedToLastFm domainEvent)
        {
            dynamic clients = GlobalHost.ConnectionManager.GetHubContext<AdminHub>().Clients.Redirect("/admin/external/lastfm");
        }
    }
}