using Domain.Core;
using Infrastructure.DomainEvents;

namespace Domain.Events.Handlers
{
    public class UpdateArtistWhenLastFmInfoWasFound: IHandleDomainEvent<LastFmInfoFound>
    {
        private readonly IArtistRepository _artistRepository;

        public UpdateArtistWhenLastFmInfoWasFound(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Handle(LastFmInfoFound domainEvent)
        {
            var artist = _artistRepository.Get(domainEvent.Artist.Id);
            artist.UpdateLastFmInfo(domainEvent.LastFmArtist.Name, domainEvent.LastFmArtist.Bio.Content);
        }
    }
}