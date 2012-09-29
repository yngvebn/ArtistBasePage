using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArtistBasePage.Infrastructure;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    [TokenAuthentication]
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

    public class TokenApiController: ApiController
    {
        private readonly IArtistRepository _artistRepository;
        public int ArtistId { get; set; }
        public TokenApiController()
        {
            _artistRepository = DependencyResolver.Current.GetService<IArtistRepository>();
        }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            IEnumerable<string> values = new List<string>();
            var token = controllerContext.Request.Headers.TryGetValues("t", out values);
            if (values == null)
                throw new HttpException(401, "Token is required");

            var artist = _artistRepository.FindByToken(values.FirstOrDefault());
            ArtistId = artist.Id; 
            base.Initialize(controllerContext);
        }
    }
}
