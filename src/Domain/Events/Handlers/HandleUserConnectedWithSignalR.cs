using Domain.Commands;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Events.Handlers
{
    public class HandleUserConnectedWithSignalR: IHandleDomainEvent<UserConnectedWithSignalR>
    {
        private readonly ICommandExecutor _commandExecutor;

        public HandleUserConnectedWithSignalR(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        public void Handle(UserConnectedWithSignalR domainEvent)
        {
            _commandExecutor.ExecuteCommand(new AddConnectionIdToUserCommand()
                {
                    ConnectionId = domainEvent.ConnectionId,
                    Username = domainEvent.Username
                });
        }
    }

    public class HandleUserDisconnectedWithSignalR : IHandleDomainEvent<UserDisconnectedWithSignalR>
    {
        private readonly ICommandExecutor _commandExecutor;

        public HandleUserDisconnectedWithSignalR(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        public void Handle(UserDisconnectedWithSignalR domainEvent)
        {
            _commandExecutor.ExecuteCommand(new RemoveConnectionIdToUserCommand()
                {
                    ConnectionId = domainEvent.ConnectionId,
                    Username = domainEvent.Username
                });
        }
    }
}