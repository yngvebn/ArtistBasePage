using Facebook.Api;

namespace ArtistBasePage.Infrastructure.Facebook
{
    public class FacebookConfig: IFacebookConfig
    {
        public string BaseUrl { get { return "https://graph.facebook.com/"; } }
        public string ClientId { get { return "159997617394589"; } }
        public string Secret { get { return "ced7de09d14698199c88de1e6c2b35ad"; } }
        public string Token { get { return "159997617394589|lxqDIRGGL-6lNMVZtERkbJTNOeM"; } }    
    }
}