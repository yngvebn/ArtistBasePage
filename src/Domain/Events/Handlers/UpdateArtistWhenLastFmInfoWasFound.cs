using System.Linq;
using Domain.Core;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Events.Handlers
{
    public class UpdateArtistWhenLastFmInfoWasFound : IHandleDomainEvent<LastFmInfoFound>
    {
        private readonly ISessionManager _sessionManager;

        public UpdateArtistWhenLastFmInfoWasFound(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void Handle(LastFmInfoFound domainEvent)
        {
            using (var session = _sessionManager.OpenSession())
            {
                var artist = session.Session.Set<Artist>().SingleOrDefault(a => a.Id == domainEvent.Artist.Id);
                artist.UpdateLastFmInfo(domainEvent.LastFmArtist.Name, domainEvent.LastFmArtist.Bio.Content);
                session.Session.SaveChanges();
            }
        }
    }
}