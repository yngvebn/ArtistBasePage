using System;
using System.Collections.Generic;
using System.Web.Http;
using ArtistBasePage.Areas.v1.ViewModels;
using ArtistBasePage.Infrastructure;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class EventController : TokenApiController
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _repository;
        private readonly IFacebookExternalRepository _facebookExternalRepository;
        private readonly ILastFmExternalRepository _lastFmExternalRepository;

        public EventController(IMapper mapper, IArtistRepository repository, IFacebookExternalRepository facebookExternalRepository, ILastFmExternalRepository lastFmExternalRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _facebookExternalRepository = facebookExternalRepository;
            _lastFmExternalRepository = lastFmExternalRepository;
        }

        public IEnumerable<EventViewModel> Get()
        {
            var artist = _repository.Get(ArtistId);
            List<EventViewModel> allEvents = new List<EventViewModel>();
            if(artist.LastFmInfo.UseEvents)
                allEvents.AddRange(_mapper.Map<IEnumerable<EventViewModel>>(_lastFmExternalRepository.GetEvents(ArtistId)));
            foreach(var ev in artist.FacebookEvents)
            {
                allEvents.Add(_mapper.Map<EventViewModel>(_facebookExternalRepository.GetEvent(ev.FacebookId)));
            }
            
            var siteEvents = _mapper.Map<IEnumerable<EventViewModel>>(artist.Events);
            allEvents.AddRange(siteEvents);
            return allEvents;
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
            if(source == (int)EventOrigin.Facebook)
            {
                Execute(new DeleteFacebookEventCommand()
                            {
                                ArtistId = ArtistId,
                                FacebookEventId = id
                            });
            }
        }
        public void Post([FromBody]CreateEventViewModel eventViewModel)
        {
            if(!string.IsNullOrEmpty(eventViewModel.FacebookEventId))
            {
                Execute(new AddFacebookEventCommand()
                {
                    ArtistId = ArtistId,
                    FacebookEventId = eventViewModel.FacebookEventId
                });
            }
            else
            {
                
            Execute(new AddNewEventCommand()
                        {
                            ArtistId = ArtistId,
                            Title = eventViewModel.Title,
                            Start = eventViewModel.Start
                        });

            }
        }
    }
}