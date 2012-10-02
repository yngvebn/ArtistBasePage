using System;
using System.Linq;
using Infrastructure.Commands;

namespace Domain.Core
{
    public class TokenRepository : ITokenRepository
    {

        private readonly ISessionManager _sessionManager;

        public TokenRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        public bool IsValid(string token)
        {
            var t = Get(token);
            if (t == null) return false;
            if (t.Expires < DateTime.Now) return false;
            return true;
        }

        public ApiToken Get(string token)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return session.Session.Set<ApiToken>().SingleOrDefault(c => c.Token == token);
            }
        }

        public ApiToken GetByCorrelationId(Guid correlationId)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return session.Session.Set<ApiToken>().SingleOrDefault(c => c.CorrelationId== correlationId);
            }
        }
    }
}