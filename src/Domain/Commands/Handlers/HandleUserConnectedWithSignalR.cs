using Domain.Core;
using Domain.Events;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{

    public class HandleUserDisconnectedWithSignalR: IHandleCommand<RemoveConnectionIdToUserCommand>
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public HandleUserDisconnectedWithSignalR(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public void Handle(RemoveConnectionIdToUserCommand command)
        {
            _userLoginRepository.Get(command.Username).DisconnectWithSignalR(command.ConnectionId);
        }
    }

    public class HandleUserConnectedWithSignalR: IHandleCommand<AddConnectionIdToUserCommand>
    {
        
        private readonly IUserLoginRepository _userLoginRepository;

        public HandleUserConnectedWithSignalR(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }
        public void Handle(AddConnectionIdToUserCommand command)
        {
            _userLoginRepository.Get(command.Username).ConnectWithSignalR(command.ConnectionId);
        }
    }
}