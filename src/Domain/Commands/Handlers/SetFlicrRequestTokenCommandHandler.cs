using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class SetFlicrRequestTokenCommandHandler: IHandleCommand<SetFlickrRequestToken>
    {
        private readonly IArtistRepository _artistRepository;

        public SetFlicrRequestTokenCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(SetFlickrRequestToken command)
        {
            _artistRepository.Get(command.ArtistId).RequestFlickrToken(command.Token, command.Secret);
        }
    }
}