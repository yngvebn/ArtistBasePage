using System.Linq;
using Infrastructure.Commands;

namespace Domain.Core
{
    public interface IUserLoginRepository
    {
        UserLogin Get(string username);
        UserLogin GetByConnectionId(string connectionId);
        void Create(string username, string password);
    }

    public class UserLoginRepository: IUserLoginRepository
    {
        private readonly ISessionManager _sessionManager;

        public UserLoginRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        
        public UserLogin Get(string username)
        {
            using(var session = _sessionManager.OpenSession())
            {
                return
                    session.Session.Set<UserLogin>().SingleOrDefault(
                        c => c.Username == username);
            }
        }

        public UserLogin GetByConnectionId(string connectionId)
        {
            using (var session = _sessionManager.OpenSession())
            {
                return
                    session.Session.Set<UserLogin>().SingleOrDefault(c => c.SignalRConnections.Any(s => s.ConnectionId == connectionId));
            }
        }

        public void Create(string username, string password)
        {
            using(var session = _sessionManager.OpenSession())
            {
                session.Session.Set<UserLogin>().Add(UserLogin.Create(username, password));
            }
        }
    }
}