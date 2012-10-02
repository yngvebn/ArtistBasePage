using Infrastructure.DomainEvents;

namespace Domain.Events
{
    public class ArtistWasConnectedToLastFm: IDomainEvent
    {
        public LastFmInfo LastFmInfo { get; set; }
        public Artist Artist { get; set; }
    }
}