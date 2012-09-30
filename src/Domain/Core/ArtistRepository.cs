using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using Infrastructure.Commands;
using Ninject;
using Ninject.Extensions.Interception;

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
                var artist = session.Session.Set<Artist>().Find(id);
                return artist;
            }
        }

        public Artist FindByEmail(string email)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return session.Session.Set<Artist>().SingleOrDefault(c => c.Email == email);
            }
        }

        public void Create(Artist artist)
        {
            using(var session = _sessionManager.OpenSession())
            {
                session.Session.Set<Artist>().Add(artist);
                
            }
        }

        public Artist FindByUsername(string username)
        {
            using(var session = _sessionManager.OpenSession())
            {
                return session.Session.Set<Artist>().SingleOrDefault(c => c.Username == username);
            }
        }

        public Artist FindByToken(string tokenKey)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return session.Session.Set<Artist>().SingleOrDefault(c => c.ApiSessions.Any(t => t.Token == tokenKey && t.Expires > DateTime.Now));
            }
        }
    }

  
}