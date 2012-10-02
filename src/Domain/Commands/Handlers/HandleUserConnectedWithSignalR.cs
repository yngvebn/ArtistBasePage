using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{

    public class HandleUserDisconnectedWithSignalR: IHandleCommand<UserDisconnectedWithSignalR>
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public HandleUserDisconnectedWithSignalR(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public void Handle(UserDisconnectedWithSignalR command)
        {
            _userLoginRepository.Get(command.Username).DisconnectWithSignalR(command.ConnectionId);
        }
    }

    public class HandleUserConnectedWithSignalR: IHandleCommand<UserConnectedWithSignalR>
    {
        
        private readonly IUserLoginRepository _userLoginRepository;

        public HandleUserConnectedWithSignalR(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }
        public void Handle(UserConnectedWithSignalR command)
        {
            _userLoginRepository.Get(command.Username).ConnectWithSignalR(command.ConnectionId);
        }
    }
}