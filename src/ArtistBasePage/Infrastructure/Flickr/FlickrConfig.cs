using Flickr;

namespace ArtistBasePage.Infrastructure.Flickr
{
    public class FlickrConfig: IFlickrConfig
    {
        public string Secret { get { return "91d56f0b487b9bc4"; } }
        public string ApiKey { get { return "f8679a3ac37364fa319db3e776cd85a9"; } }
        public string OAuthRequestTokenCallbackUrl { get { return "http://localhost:54944/admin/flickr/authcallback/{0}"; } }
    }
}