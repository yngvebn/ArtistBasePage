using System.Collections.Generic;
using System.Web.Http;
using ArtistBasePage.Infrastructure;
using Domain;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class SocialNetworksController : TokenApiController
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;

        public SocialNetworksController(IMapper mapper, IArtistRepository artistRepository)
        {
            _mapper = mapper;
            _artistRepository = artistRepository;
        }

        public IEnumerable<SocialNetworkViewModel> Get()
        {
            return _mapper.Map<IEnumerable<SocialNetworkViewModel>>(_artistRepository.Get(ArtistId).SocialNetworks);
        }

        public void Post([FromBody]SocialNetworkViewModel socialNetworkViewModel)
        {
            Execute(new AddSocialNetworkCommand()
                        {
                            ArtistId = ArtistId,
                            SocialNetworkType = socialNetworkViewModel.Type.ParseEnum<SocialNetworkType>(),
                            Url = socialNetworkViewModel.Url
                        });
        }

        public void Delete(SocialNetworkType id)
        {
            MvcApplication.CommandExecutor.ExecuteCommand(new DeleteSocialNetworkCommand()
                                                              {ArtistId = ArtistId, Type = id});
        }
    }
}