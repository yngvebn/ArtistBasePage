using System.Collections.Generic;
using System.Web.Http;
using ArtistBasePage.Areas.v1.ViewModels;
using ArtistBasePage.Infrastructure;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class LastFmController: TokenApiController
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        [HttpPost]
        public void Connect()
        {
            Execute(new ConnectArtistToLastFm()
                        {
                            ArtistId = ArtistId
                        });
        }

        public LastFmController(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public LastFmInfoViewModel Get()
        {
            var lastFmInfo = _artistRepository.Get(ArtistId).LastFmInfo;
            return _mapper.Map<LastFmInfoViewModel>(lastFmInfo);
        }

        public void Put([FromBody]LastFmInfoViewModel model)
        {
            Execute(new UpdateLastFmInfoCommand()
                        {
                            ArtistId = ArtistId,
                            UseBio = model.UseBio,
                            UseEvents = model.UseEvents
                        });
        }
    }
}