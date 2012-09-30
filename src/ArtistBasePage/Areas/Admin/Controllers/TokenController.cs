using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArtistBasePage.Areas.v1.ViewModels;
using ArtistBasePage.Infrastructure;
using Domain;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    public class TokenController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;

        public TokenController(IMapper mapper, IArtistRepository artistRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
        }



        public JsonResult RequestToken(int? id)
        {

            if (User.Identity.IsAuthenticated)
            {
                var artists = _artistRepository.FindByUsername(User.Identity.Name);
                return RequestReadWrite(artists);
            }
            else
            {
                if (!id.HasValue) throw new HttpException(404, "Artist ID is required");
                var artist = _artistRepository.Get(id.Value);
                return RequestRead(new Artist[] { artist });
            }
        }

        private JsonResult RequestRead(IEnumerable<Artist> artists)
        {
            List<ApiSessionViewModel> tokens = new List<ApiSessionViewModel>();
            foreach (var artist in artists)
            {
                MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadOnlyToken() { ArtistId = artist.Id });
                var token = _mapper.Map<ApiSessionViewModel>(artist.ApiSessions.Where(c => !c.Write).SingleOrDefault(c => c.Expires > DateTime.Now));
                token.ArtistId = artist.Id;
                tokens.Add(token);
            }
            return Json(tokens, JsonRequestBehavior.AllowGet);
        }

        private JsonResult RequestReadWrite(IEnumerable<Artist> artists)
        {
            List<ApiSessionViewModel> tokens = new List<ApiSessionViewModel>();
            foreach(var artist in artists)
            {
            MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadWriteToken() { ArtistId = artist.Id });
                var token =
                    _mapper.Map<ApiSessionViewModel>(
                        artist.ApiSessions.Where(c => c.Write && c.Read).SingleOrDefault(c => c.Expires > DateTime.Now));
                token.ArtistId = artist.Id;
                tokens.Add(token);
            }
            return Json(tokens, JsonRequestBehavior.AllowGet);
        }
    }
}
