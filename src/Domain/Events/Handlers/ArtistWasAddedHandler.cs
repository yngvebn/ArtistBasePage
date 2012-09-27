using Domain.Core;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Events.Handlers
{
    public class ArtistWasAddedHandler: IDomainEventHandler<ArtistWasAdded>
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistWasAddedHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(ArtistWasAdded domainEvent)
        {
       
        }
    }
}