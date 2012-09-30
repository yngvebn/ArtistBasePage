using System;
using System.Linq;
using System.Web.Security;
using Domain;
using Domain.Core;

namespace ArtistBasePage.Infrastructure
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IArtistRepository _artistRepository;

        public AuthenticationService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public bool Validate(string username, string password)
        {
            var artists = _artistRepository.FindByUsername(username);
            if(!artists.Any()) throw new UserDoesNotExistException(username);
            return artists.Any(c => c.Logins.Any(u => u.Username == username && u.Password == password.Encrypt()));
        }

        public void Login(string username)
        {
            FormsAuthentication.SetAuthCookie(username, true);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }

    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException(string username)
            :base(string.Format("User with username {0} does not find", username))
        {
        }
    }
}