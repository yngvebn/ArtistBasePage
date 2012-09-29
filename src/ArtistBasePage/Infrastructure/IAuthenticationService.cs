using System;
using System.Web.Security;
using Domain.Core;

namespace ArtistBasePage.Infrastructure
{
    public interface IAuthenticationService
    {
        bool Validate(string username, string password);
        void Login(string username);
        void Logout();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IArtistRepository _artistRepository;

        public AuthenticationService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public bool Validate(string username, string password)
        {
            var artist = _artistRepository.FindByUsername(username);
            if(artist == null) throw new UserDoesNotExistException(username);
            return artist.IsValidPassword(password);
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
        public string Username { get; private set; }

        public UserDoesNotExistException(string username)
        {
            Username = username;
        }
    }
}