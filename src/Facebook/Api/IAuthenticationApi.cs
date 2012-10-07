using Facebook.Api.Rest;
using RestSharp;

namespace Facebook.Api
{
    public interface IAuthenticationApi
    {
        AccessToken GetAccessToken();
    }

    public class AutenticationApi: FacebookApiBase, IAuthenticationApi
    {
        public AutenticationApi(IFacebookApi api)
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

    public class AccessToken
    {
        public string Token { get; set; }

        public AccessToken(string token)
        {
            Token = token;
        }
    }
}