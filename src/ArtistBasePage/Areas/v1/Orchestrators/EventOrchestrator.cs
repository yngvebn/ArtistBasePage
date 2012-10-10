using System.Collections.Generic;
using System.Linq;
using ArtistBasePage.Areas.v1.ViewModels;
using ArtistBasePage.Infrastructure;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Orchestrators
{
    public class EventOrchestrator: Orchestrator, IEventOrchestrator
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _repository;
        private readonly IFacebookExternalRepository _facebookExternalRepository;
        private readonly ILastFmExternalRepository _lastFmExternalRepository;

        public EventOrchestrator(IMapper mapper, IArtistRepository repository, IFacebookExternalRepository facebookExternalRepository, ILastFmExternalRepository lastFmExternalRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _facebookExternalRepository = facebookExternalRepository;
            _lastFmExternalRepository = lastFmExternalRepository;
        }


        public IEnumerable<EventViewModel> Get(int artistId)
        {
            var artist = _repository.Get(artistId);
            var allEvents = new List<EventViewModel>();
            if (artist.LastFmInfo.UseEvents)
            {
                allEvents.AddRange(_mapper.Map<IEnumerable<EventViewModel>>(_lastFmExternalRepository.GetEvents(artistId)));
            }
            allEvents.AddRange(artist.FacebookEvents.Select(ev => _mapper.Map<EventViewModel>(_facebookExternalRepository.GetEvent(ev.FacebookId))));

            var siteEvents = _mapper.Map<IEnumerable<EventViewModel>>(artist.Events);
            allEvents.AddRange(siteEvents);
            return allEvents;
        }

        public void Delete(int artistId, string id, int source)
        {
            if (source == (int)EventOrigin.Facebook)
            {
                Execute(new DeleteFacebookEventCommand()
                {
                    ArtistId = artistId,
                    FacebookEventId = id
                });
            }
        }

        public void Create(int artistId, CreateEventViewModel eventViewModel)
        {
            if (!string.IsNullOrEmpty(eventViewModel.FacebookEventId))
            {
                Execute(new AddFacebookEventCommand()
                {
                    ArtistId = artistId,
                    FacebookEventId = eventViewModel.FacebookEventId
                });
            }
            else
            {

                Execute(new AddNewEventCommand()
                {
                    ArtistId = artistId,
                    Title = eventViewModel.Title,
                    Start = eventViewModel.Start
                });

            }
        }
    }
}