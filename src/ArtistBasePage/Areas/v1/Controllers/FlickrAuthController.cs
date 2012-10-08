using System.Web.Mvc;
using ArtistBasePage.Areas.v1.Controllers;
using ArtistBasePage.Infrastructure;
using Domain.Commands;
using Flickr;
using FlickrNet;

namespace ArtistBasePage.Areas.Admin.Controllers
{

    public class FlickrAuthController: TokenApiController
    {
        private readonly IFlickrApi _flickrApi;

        public FlickrAuthController(IFlickrApi flickrApi)
        {
            _flickrApi = flickrApi;
        }

        public string Auth()
        {
            var token = _flickrApi.GetRequestToken();
            Execute(new SetFlickrRequestToken()
                        {
                            ArtistId = ArtistId,
                            Token = token.Token,
                            Secret = token.TokenSecret
                        });
            var url = _flickrApi.GetAuthUrl(string.Format(token.Token, ArtistId));
            return url;
        }

        [TokenAuthentication(RequireToken = false)]
        public string AuthCallback(string id, string oauth_token, string oauth_verifier)
        {
            //var requestToken = Session["__flickrtoken"] as OAuthRequestToken;
            //var access = _flickrApi.GetAccessToken(requestToken, oauth_verifier);
            //MvcApplication.CommandExecutor.ExecuteCommand(new AuthenticateWithFlickrCommand()
            //                                                  {
            //                                                      ArtistId = ArtistId,
            //                                                      Token = access.Token,
            //                                                      Secret = access.TokenSecret
            //                                                  });
            return "";
        }


    }
}
