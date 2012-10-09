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
        OAuthRequestToken GetRequestToken(string apiToken);
        OAuthAccessToken GetAccessToken(OAuthRequestToken token, string verifier);
        string GetAuthUrl(string token);
    }

    public class FlickrApi : IFlickrApi
    {
        private readonly IFlickrConfig _config;
        private readonly FlickrNet.Flickr _flickr;
        public FlickrApi(IFlickrConfig config)
        {

            
            _config = config;
            _flickr = new FlickrNet.Flickr(_config.ApiKey, _config.Secret);
        
        }

        public OAuthRequestToken GetRequestToken(string apiToken)
        {
            return _flickr.OAuthGetRequestToken(string.Format(_config.OAuthRequestTokenCallbackUrl, apiToken));
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
