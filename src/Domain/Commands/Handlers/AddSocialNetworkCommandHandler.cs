using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class AddSocialNetworkCommandHandler: ICommandHandler<AddSocialNetworkCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public AddSocialNetworkCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(AddSocialNetworkCommand command)
        {
            _artistRepository.Get(command.ArtistId).SetSocialNetwork(command.SocialNetworkType, command.Url);
        }
    }
}