using Domain.Core;

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
            using(var session = _sessionManager.OpenSession())
            {
                session.Session.Set<Artist>().Add(Artist.Create(command.Email));
            }
        }
    }
}