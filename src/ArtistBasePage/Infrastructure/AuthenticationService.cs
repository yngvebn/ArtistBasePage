using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Domain;
using Domain.Core;

namespace ArtistBasePage.Infrastructure
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public AuthenticationService(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public IEnumerable<Artist> GetUserArtists(string username, string password)
        {
            var login = _userLoginRepository.Get(username);
            if(login == null) throw new UserDoesNotExistException(username);
            if (login.Password != password.Encrypt()) throw new InvalidPasswordException(username);
            return login.Artists;
        }

        public bool Validate(string username, string password)
        {
            return _userLoginRepository.Get(username).Password.Equals(password.Encrypt());
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

    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string username)
            :base(string.Format("The password supplied for user {0} is incorrect", username))
        {
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