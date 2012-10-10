using System.Web.Http;
using ArtistBasePage.Areas.v1.Core;
using ArtistBasePage.Infrastructure;
using Domain;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class ArtistController : TokenApiController
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;

        public ArtistController(IMapper mapper, IArtistRepository artistRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
        }

        
        public ArtistViewModel Get()
        {
            return _mapper.Map<ArtistViewModel>(_artistRepository.Get(ArtistId));
        }
        
        public void Put([FromBody]ArtistViewModel artist)
        {
            Execute(new UpdateArtistCommand()
                        {
                            ArtistId = ArtistId,
                            Artist = _mapper.Map<Artist>(artist)
                        });
        }

    }
}
