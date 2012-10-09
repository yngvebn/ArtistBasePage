using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Commands;
using Domain.Core;
using Flickr;
using FlickrNet;

namespace ArtistBasePage.Areas.OAuth.Controllers
{
    public class FlickrController : Controller
    {
        private readonly IFlickrApi _flickrApi;
        private readonly IArtistRepository _artistRepository;

        public FlickrController(IFlickrApi flickrApi, IArtistRepository artistRepository)
        {
            _flickrApi = flickrApi;
            _artistRepository = artistRepository;
        }

        public ActionResult Auth(string id)
        {
            var artist = _artistRepository.FindByToken(id);
            var token = _flickrApi.GetRequestToken(id);
            
            MvcApplication.CommandExecutor.ExecuteCommand(new SetFlickrRequestToken()
            {
                ArtistId = artist.Id,
                Token = token.Token,
                Secret = token.TokenSecret
            });
            var url = _flickrApi.GetAuthUrl(token.Token);
            return Redirect(url);
        }


        public ActionResult AuthCallback(string id, string oauth_token, string oauth_verifier)
        {
            var artist = _artistRepository.FindByToken(id);
            var requestToken = new OAuthRequestToken()
                {
                    Token = artist.FlickrInfo.RequestToken,
                    TokenSecret = artist.FlickrInfo.RequestSecret
                };
            var access = _flickrApi.GetAccessToken(requestToken, oauth_verifier);
            MvcApplication.CommandExecutor.ExecuteCommand(new AuthenticateWithFlickrCommand()
                                                              {
                                                                  ArtistId = artist.Id,
                                                                  Token = access.Token,
                                                                  Secret = access.TokenSecret
                                                              });
            return View("Success");
        }
    }
}
