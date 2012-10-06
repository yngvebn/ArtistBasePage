using System.Collections.Generic;
using System.Web.Http;
using ArtistBasePage.Areas.v1.ViewModels;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class EventController: TokenApiController
    {
        private readonly IArtistRepository _repository;
        private readonly ILastFmExternalRepository _lastFmExternalRepository;

        public EventController(IArtistRepository repository, ILastFmExternalRepository lastFmExternalRepository)
        {
            _repository = repository;
            _lastFmExternalRepository = lastFmExternalRepository;
        }

        public IEnumerable<object> Get()
        {
            return _lastFmExternalRepository.GetEvents(ArtistId);
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