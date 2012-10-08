using System.Web.Mvc;
using Domain.Commands;
using Flickr;
using FlickrNet;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    [Authorize]
    public class FlickrAuthController: Controller
    {
        private readonly IFlickrApi _flickrApi;

        public FlickrAuthController(IFlickrApi flickrApi)
        {
            _flickrApi = flickrApi;
        }

        //public ActionResult Auth()
        //{
        //    var token = _flickrApi.GetRequestToken();
        //    Session.Add("__flickrtoken", token);
        //    var url = _flickrApi.GetAuthUrl(token.Token);
        //    return Redirect(url);
        //}

        //public ActionResult AuthCallback(string oauth_token, string oauth_verifier)
        //{
        //    var requestToken = Session["__flickrtoken"] as OAuthRequestToken;
        //    var access = _flickrApi.GetAccessToken(requestToken, oauth_verifier);
        //    MvcApplication.CommandExecutor.ExecuteCommand(new AuthenticateWithFlickrCommand()
        //                                                      {
        //                                                          ArtistId = ArtistId,
        //                                                          Token = access.Token,
        //                                                          Secret = access.TokenSecret
        //                                                      });
        //    return View();
        //}


    }
}
