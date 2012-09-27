using Infrastructure.DomainEvents;

namespace Domain.Events
{
    public class ArtistWasAdded: IDomainEvent
    {
        public Artist Artist { get; set; } 
    }
}