using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Core;
using SignalR.Hubs;

namespace ArtistBasePage.Areas.Admin.Hubs
{


    public class StatusHub : Hub, IConnected, IDisconnect
    {
        // This will only work on a single server
        private static readonly ConcurrentDictionary<string, List<string>> _userConnections = new ConcurrentDictionary<string, List<string>>();

        // This is needed for disconnect since we don't get the state propagated to us
        private static readonly ConcurrentDictionary<string, string> _reverseLookup = new ConcurrentDictionary<string, string>();

        public Task Connect()
        {
            if (string.IsNullOrEmpty(Context.User.Identity.Name)) return null;
            EnsureAuthented();

            // Make a new slot of get a list of connections for this user name
            var connections = _userConnections.GetOrAdd(Context.User.Identity.Name, _ => new List<string>());

            // Also add the reverse lookup (a mapping from connection id to user name)
            _reverseLookup.TryAdd(Context.ConnectionId, Context.User.Identity.Name);

            lock (connections)
            {
                // Add the connection to the list of connections. This allows one user to log in from
                // different clients (broser tabs, browsers, mobile devices, other apps, etc),
                // and have them all be synchronized.
                connections.Add(Context.ConnectionId);
                MvcApplication.CommandExecutor.ExecuteCommand(new AddConnectionIdToUserCommand()
                                                                  {
                                                                      ConnectionId = Context.ConnectionId,
                                                                      Username = Context.User.Identity.Name
                                                                  });
            }

            return Clients[Context.ConnectionId].connected(Context.User.Identity);
        }

        public Task Reconnect(IEnumerable<string> groups)
        {
            if (groups.Any())
            {
                throw new InvalidOperationException("You shouldn't be in any groups!");
            }

            return null;
        }

        public void Test()
        {

        }
        public Task Disconnect()
        {
            List<string> connections;
            string userName;

            // Since the other information may not be available when disconnect is fired,
            // we keep track of which user name a connection id is associated with
            if (_reverseLookup.TryRemove(Context.ConnectionId, out userName) &&
                _userConnections.TryGetValue(userName, out connections))
            {
                lock (connections)
                {
                    // Remove the connection from the list of connections
                    connections.Remove(Context.ConnectionId);

                    MvcApplication.CommandExecutor.ExecuteCommand(new RemoveConnectionIdToUserCommand()
                    {
                        ConnectionId = Context.ConnectionId
                    });
                }

                // In case this is a browser refresh, wait a few milli seconds before removing all connections
                // This way, hitting f5 don't suddenly cause an offline/online flip
                Thread.Sleep(100);

                if (connections.Count == 0)
                {
                    _userConnections.TryRemove(userName, out connections);



                    return null;
                }
            }

            return null;
        }

        private void EnsureAuthented()
        {
            // Makes sure the user is logged in via forms auth
            if (!Context.User.Identity.IsAuthenticated)
            {
                throw new InvalidOperationException("You're not authenticated");
            }
        }
    }
}