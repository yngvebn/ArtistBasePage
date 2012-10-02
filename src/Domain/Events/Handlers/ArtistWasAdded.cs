using Domain.Core;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Events.Handlers
{
    public class ArtistWasAdded: IHandleDomainEvent<Events.ArtistWasAdded>
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistWasAdded(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(Events.ArtistWasAdded domainEvent)
        {
       
        }
    }
}