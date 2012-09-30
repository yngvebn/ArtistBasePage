namespace ArtistBasePage.Infrastructure
{
    public interface IAuthenticationService
    {
        bool Validate(string username, string password);
        void Login(string username);
        void Logout();
    }
}