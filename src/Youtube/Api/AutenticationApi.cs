using RestSharp;
using Youtube.Api.Rest;
using Youtube.Models;

namespace Youtube.Api
{
    public class AutenticationApi: YoutubeApiBase, IAuthenticationApi
    {
        public AutenticationApi(IYoutubeApi api)
            :base(api)
        {
            
        }

        public AccessToken GetAccessToken()
        {
            var call = Rest.Method("/oauth/access_token", Method.POST)
                .AddParam("client_id", Api.Config.ClientId)
                .AddParam("grant_type", "client_credentials")
                .AddParam("client_secret", Api.Config.Secret);

            var token = call.Execute();
            return new AccessToken(token.Replace("access_token=", ""));
        }
    }
}