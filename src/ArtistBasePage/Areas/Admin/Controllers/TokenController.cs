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
        private readonly ITokenRepository _tokenRepository;

        public TokenController(IMapper mapper, IArtistRepository artistRepository, ITokenRepository tokenRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
            _tokenRepository = tokenRepository;
        }



        public JsonResult RequestToken(int id)
        {

            if (User.Identity.IsAuthenticated)
            {
                var artist = _artistRepository.Get(id);
                if (artist.Logins.All(c => c.Username != User.Identity.Name))
                    throw new HttpException(401, "Unauthorized");
                return RequestReadWrite(artist);
            }
            else
            {
                var artist = _artistRepository.Get(id);
                return RequestRead(artist);
            }
        }

        private JsonResult RequestRead(Artist artist)
        {
            Guid correlationId = Guid.NewGuid();
            MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadOnlyToken() { ArtistId = artist.Id, CorrelationId = correlationId });
            var token = _tokenRepository.GetByCorrelationId(correlationId);
            return Json(_mapper.Map<ApiSessionViewModel>(token), JsonRequestBehavior.AllowGet);
        }

        private JsonResult RequestReadWrite(Artist artist)
        {
            Guid correlationId = Guid.NewGuid();
            MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadWriteToken() { ArtistId = artist.Id, CorrelationId = correlationId });
            var token = _tokenRepository.GetByCorrelationId(correlationId);
            return Json(_mapper.Map<ApiSessionViewModel>(token), JsonRequestBehavior.AllowGet);
        }
    }
}
