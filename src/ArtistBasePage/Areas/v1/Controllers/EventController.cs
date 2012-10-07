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

        public IEnumerable<object> Get()
        {
            var artist = _repository.Get(ArtistId);
            List<EventViewModel> allEvents = new List<EventViewModel>();
            var lastFmEvents = _mapper.Map<IEnumerable<EventViewModel>>(_lastFmExternalRepository.GetEvents(ArtistId));
            foreach(var ev in artist.FacebookEvents)
            {
                allEvents.Add(_mapper.Map<EventViewModel>(_facebookExternalRepository.GetEvent(ev.FacebookId)));
            }
            
            var siteEvents = _mapper.Map<IEnumerable<EventViewModel>>(artist.Events);
            allEvents.AddRange(lastFmEvents);
            allEvents.AddRange(siteEvents);
            return allEvents;
        }

        public void Post([FromBody]CreateEventViewModel eventViewModel)
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