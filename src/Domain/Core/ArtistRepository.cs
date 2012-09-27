using System.Linq;

namespace Domain.Core
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ISessionManager _sessionManager;

        public ArtistRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public Artist Get(int id)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return session.Session.Artists.Find(id);
            }
        }

        public Artist FindByEmail(string email)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return session.Session.Artists.SingleOrDefault(c => c.Email == email);
            }
        }
    }
}