using System.Collections.Generic;
using Domain;

namespace ArtistBasePage.Infrastructure
{
    public interface IAuthenticationService
    {
        IEnumerable<Artist> GetUserArtists(string username, string password);
        void Login(string username);
        void Logout();
    }
}