using Domain.Core;
using Domain.Events;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Commands.Handlers
{
    public class AddNewArtistCommandHandler: ICommandHandler<AddNewArtist>
    {
        private readonly ISessionManager _sessionManager;

        public AddNewArtistCommandHandler(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void Handle(AddNewArtist command)
        {
            var artist = Artist.Create(command.Email);
            using(var session = _sessionManager.OpenSession())
            {
                session.Session.Set<Artist>().Add(artist);
            }
            DomainEvents.Raise(new ArtistWasAdded() { Artist = artist });
        }
    }
}