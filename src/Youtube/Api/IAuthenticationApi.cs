using Youtube.Models;

namespace Youtube.Api
{
    public interface IAuthenticationApi
    {
        AccessToken GetAccessToken();
    }
}