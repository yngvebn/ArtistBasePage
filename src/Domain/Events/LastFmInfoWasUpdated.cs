using Infrastructure.DomainEvents;

namespace Domain.Events
{
    public class LastFmInfoWasUpdated: IDomainEvent
    {
        public LastFmInfo Info { get; set; }
    }
}