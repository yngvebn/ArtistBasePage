using ArtistBasePage.Areas.Admin.Hubs;
using ArtistBasePage.Areas.Admin.ViewModels;
using Domain.Events;
using Infrastructure.DomainEvents;
using SignalR;

namespace ArtistBasePage.Infrastructure.EventHandlers
{
    public class NotifyAdminWhenLastFmInformationFound: IHandleDomainEvent<NotificationAdded>
    {
        public void Handle(NotificationAdded domainEvent)
        {
            GlobalHost.ConnectionManager.GetHubContext<AdminHub>().Clients.Notify(new NotificationViewModel()
            {
                Content = domainEvent.LastNotification.Content,
                Title = domainEvent.LastNotification.Title,
                AcceptAction = domainEvent.LastNotification.AcceptAction,
               CancelText = domainEvent.LastNotification.CancelText
            });
        }
    }
}