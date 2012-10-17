using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class RegisterNewUserCommandHandler: IHandleCommand<RegisterNewUserCommand>
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public RegisterNewUserCommandHandler(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public void Handle(RegisterNewUserCommand command)
        {
            _userLoginRepository.Create(command.Username, command.Password);
        }
    }
}