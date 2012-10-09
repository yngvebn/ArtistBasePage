using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class AuthenticateWithFlickrCommandHandler: IHandleCommand<AuthenticateWithFlickrCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public AuthenticateWithFlickrCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(AuthenticateWithFlickrCommand command)
        {
            _artistRepository.Get(command.ArtistId).ConnectToFlickr(command.Token, command.Secret);
        }
    }
}