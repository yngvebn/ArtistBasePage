using System.Linq;
using Infrastructure.Commands;

namespace Domain.Core
{
    public interface IUserLoginRepository
    {
        UserLogin Get(string username);
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
    }
}