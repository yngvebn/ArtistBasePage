using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlickrNet;

namespace Flickr
{
    public interface IFlickrApi
    {
        OAuthRequestToken GetRequestToken();
        OAuthAccessToken GetAccessToken(OAuthRequestToken token, string verifier);
        string GetAuthUrl(string token);
    }

    public class FlickrApi : IFlickrApi
    {
        private readonly IFlickrConfig _config;
        private readonly FlickrNet.Flickr _flickr;
        public FlickrApi(IFlickrConfig config)
        {
            _flickr = new FlickrNet.Flickr(_config.ApiKey, _config.Secret);
        
            _config = config;
        }

        public OAuthRequestToken GetRequestToken()
        {
            return _flickr.OAuthGetRequestToken(_config.OAuthRequestTokenCallbackUrl);
        }

        public OAuthAccessToken GetAccessToken(OAuthRequestToken token, string verifier)
        {
            var access = _flickr.OAuthGetAccessToken(token, verifier);
            return access;
        }

        public string GetAuthUrl(string requestToken)
        {
            return _flickr.OAuthCalculateAuthorizationUrl(requestToken, AuthLevel.Read);
        }
    }

    public interface IFlickrConfig
    {
        string Secret { get; }
        string ApiKey { get; }
        string OAuthRequestTokenCallbackUrl { get; }
    }
}
