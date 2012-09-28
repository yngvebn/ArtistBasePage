using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArtistBasePage.Infrastructure;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class ArtistController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;

        public ArtistController(IMapper mapper, IArtistRepository artistRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
        }

        // GET api/general
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/general/5
        public ArtistViewModel Get(int id)
        {
            return _mapper.Map<ArtistViewModel>(_artistRepository.Get(id));
        }

        // POST api/general
        public void Post([FromBody]string value)
        {
        }

        // PUT api/general/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/general/5
        public void Delete(int id)
        {
        }
    }
}
