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

namespace ArtistBasePage.Areas.v1.Controllers
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

        public JsonResult RequestToken(int id)
        {
            var artist = _artistRepository.Get(id);
            if(User.Identity.IsAuthenticated && artist.Username == User.Identity.Name)
            {
                return RequestReadWrite(artist);
            }
            else
            {
                return RequestRead(artist);
            }
        }

        private JsonResult RequestRead(Artist artist)
        {
            MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadOnlyToken() { ArtistId = artist.Id });
            var token = artist.ApiSessions.Where(c => !c.Write).SingleOrDefault(c => c.Expires > DateTime.Now);
            return Json(_mapper.Map<ApiSessionViewModel>(token), JsonRequestBehavior.AllowGet);
        }

        private JsonResult RequestReadWrite(Artist artist)
        {
            MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadWriteToken() { ArtistId = artist.Id });
            var token = artist.ApiSessions.Where(c => c.Write && c.Read).SingleOrDefault(c => c.Expires > DateTime.Now);
            return Json(_mapper.Map<ApiSessionViewModel>(token), JsonRequestBehavior.AllowGet);
        }
    }
}
