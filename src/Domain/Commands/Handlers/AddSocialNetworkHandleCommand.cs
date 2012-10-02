using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class AddSocialNetworkHandleCommand: IHandleCommand<AddSocialNetworkCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public AddSocialNetworkHandleCommand(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(AddSocialNetworkCommand command)
        {
            _artistRepository.Get(command.ArtistId).SetSocialNetwork(command.SocialNetworkType, command.Url);
        }
    }
}