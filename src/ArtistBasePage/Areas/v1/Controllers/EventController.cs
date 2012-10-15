using System;
using System.Collections.Generic;
using System.Web.Http;
using ArtistBasePage.Areas.v1.Core;
using ArtistBasePage.Areas.v1.Orchestrators;
using ArtistBasePage.Areas.v1.ViewModels;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{

    public class FacebookTokenController: TokenApiController
    {
        private readonly IFacebookExternalRepository _facebookExternalRepository;

        public FacebookTokenController(IFacebookExternalRepository facebookExternalRepository)
        {
            _facebookExternalRepository = facebookExternalRepository;
        }

        public string Get()
        {
            return _facebookExternalRepository.GetAccessToken();
        }
    }
    public class EventController : TokenApiController
    {
        private readonly IEventOrchestrator _orchestrator;

        public EventController(IEventOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public IEnumerable<EventViewModel> Get()
        {
            return _orchestrator.Get(ArtistId);
        }

        [HttpDelete]
        public void Delete(string id, int source)
        {
            _orchestrator.Delete(ArtistId, id, source);
           
        }
        public void Post([FromBody]CreateEventViewModel eventViewModel)
        {
            _orchestrator.Create(ArtistId, eventViewModel);
        }
    }
}