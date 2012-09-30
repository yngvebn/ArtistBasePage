using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class DeleteSocialNetworkCommandHandler: ICommandHandler<DeleteSocialNetworkCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public DeleteSocialNetworkCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(DeleteSocialNetworkCommand command)
        {
            _artistRepository.Get(command.ArtistId).RemoveSocialNetwork(command.Type);
        }
    }
}