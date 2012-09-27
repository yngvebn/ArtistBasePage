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

        public JsonResult RequestRead(int id)
        {
            MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadOnlyToken() { ArtistId = id });
            var token = _artistRepository.Get(id).ApiSessions.SingleOrDefault(c => c.Expires > DateTime.Now);
            return Json(_mapper.Map<ApiSessionViewModel>(token), JsonRequestBehavior.AllowGet);
        }

    }
}
