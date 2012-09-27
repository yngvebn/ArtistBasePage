using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArtistBasePage.Areas.v1.ViewModels;
using ArtistBasePage.Infrastructure;
using Domain;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class TokenController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;

        public TokenController(IMapper mapper, IArtistRepository artistRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
        }

        public ApiSessionViewModel Get()
        {
            return _mapper.Map<ApiSessionViewModel, ApiSession>(_artistRepository.Get(1).GetReadonlyToken());
        }

    }
}
