using Infrastructure.Commands;

namespace Domain.Commands
{
    public class RegisterNewUserCommand: Command
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}