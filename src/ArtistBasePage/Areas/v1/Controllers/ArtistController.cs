using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        // GET api/general
        public ArtistViewModel Get()
        {
            return _mapper.Map<ArtistViewModel>(_artistRepository.Get(ArtistId));
        }

        // POST api/general
        public void Post([FromBody]string value)
        {
        }

        public void Put([FromBody]ArtistViewModel artist)
        {
            Execute(new UpdateArtistCommand()
                        {
                            ArtistId = ArtistId,
                            Artist = _mapper.Map<Artist>(artist)
                        });
        }

        // DELETE api/general/5
        public void Delete(int id)
        {
        }
    }
}
