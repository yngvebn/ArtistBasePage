using DotLastFm.Models;
using Infrastructure.DomainEvents;

namespace Domain.Events
{
    public class LastFmInfoFound: IDomainEvent
    {
        public Artist Artist { get; set; }

        public ArtistWithDetails LastFmArtist { get; set; }
    }
}