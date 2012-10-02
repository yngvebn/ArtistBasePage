using Infrastructure.DomainEvents;

namespace Domain.Events
{
    public class ArtistWasUpdated: IDomainEvent
    {
        public Artist Artist { get; set; }
    }
}