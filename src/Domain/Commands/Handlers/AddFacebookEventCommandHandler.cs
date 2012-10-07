using Domain.Core;
using Domain.Events;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Commands.Handlers
{
    public class AddFacebookEventCommandHandler : IHandleCommand<AddFacebookEventCommand>
    {
        private readonly IArtistRepository _artistRepository;

        public AddFacebookEventCommandHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(AddFacebookEventCommand command)
        {
            _artistRepository.Get(command.ArtistId).AddFacebookEvent(command.FacebookEventId);
            DomainEvents.Raise(new EventWasAdded());
        }
    }
}