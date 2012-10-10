using System;
using System.Collections.Generic;
using System.Web.Http;
using ArtistBasePage.Areas.v1.Core;
using ArtistBasePage.Areas.v1.Orchestrators;
using ArtistBasePage.Areas.v1.ViewModels;
using ArtistBasePage.Infrastructure;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class EventController : TokenApiController
    {
        private readonly IEventOrchestrator _orchestrator;
        private readonly IMapper _mapper;
        private readonly IFacebookExternalRepository _facebookExternalRepository;

        public EventController(IEventOrchestrator orchestrator, IMapper mapper, IFacebookExternalRepository facebookExternalRepository)
        {
            _orchestrator = orchestrator;
            _mapper = mapper;
            _facebookExternalRepository = facebookExternalRepository;
        }

        public IEnumerable<EventViewModel> Get()
        {
            return _orchestrator.Get(ArtistId);
        }

        [HttpGet]
        public EventViewModel Facebook(string url)
        {
            Uri uri = new Uri(url);
            var id = uri.Segments[2].Replace("/", "");
            var ev = _facebookExternalRepository.GetEvent(id);
            return _mapper.Map<EventViewModel>(ev);
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