using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Core;
using Infrastructure.Commands;
using SignalR.Hubs;

namespace ArtistBasePage.Areas.Admin.Hubs
{
    public class AdminHub: Hub, IConnected, IDisconnect
    {

        public Task Connect()
        {
            if (Context.User == null) return null;
            return Task.Factory.StartNew(() =>
            MvcApplication.CommandExecutor.ExecuteCommand(new UserConnectedWithSignalR()
                                                              {
                                                                  Username = Context.User.Identity.Name,
                                                                  ConnectionId = Context.ConnectionId
                                                              }));
        }

        public Task Reconnect(IEnumerable<string> groups)
        {
            return null;
        }

        public Task Disconnect()
        {
            if (Context.User == null) return null;
           return Task.Factory.StartNew(() => MvcApplication.CommandExecutor.ExecuteCommand(new UserDisconnectedWithSignalR()
            {
                Username = Context.User.Identity.Name,
                ConnectionId = Context.ConnectionId
            }));
        }
    }


}