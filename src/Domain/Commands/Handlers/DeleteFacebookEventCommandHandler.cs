using Domain.Core;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class DeleteFacebookEventCommandHandler: IHandleCommand<DeleteFacebookEventCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public DeleteFacebookEventCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(DeleteFacebookEventCommand command)
        {
            _artistRepository.Get(command.ArtistId).RemoveFacebookEvent(command.FacebookEventId);
        }
    }
}