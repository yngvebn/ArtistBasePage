using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Core;
using Domain.Events;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;
using SignalR.Hubs;

namespace ArtistBasePage.Areas.Admin.Hubs
{
    public class AdminHub : Hub //, IConnected, IDisconnect
    {

        //public Task Connect()
        //{
        //    if (Context.User == null || string.IsNullOrEmpty(Context.User.Identity.Name)) return null;
        //    DomainEvents.Raise(new UserConnectedWithSignalR()
        //                           {
        //                               Username = Context.User.Identity.Name,
        //                               ConnectionId = Context.ConnectionId
        //                           });
        //    return Task.Factory.StartNew(() => { });

        //}

        //public Task Reconnect(IEnumerable<string> groups)
        //{
        //    return null;
        //}

        //public Task Disconnect()
        //{
            
        //    DomainEvents.Raise(new UserDisconnectedWithSignalR()
        //     {
        //         ConnectionId = Context.ConnectionId
        //     });
        //    return Task.Factory.StartNew(() => { });
        //}
    }


}