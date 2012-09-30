using ArtistBasePage.Areas.v1.Controllers;
using Domain;

namespace ArtistBasePage.Infrastructure.Mappings
{
    public class DomainMappings: IMapping
    {
        public void Setup()
        {
            AutoMapper.Mapper.CreateMap<ArtistViewModel, Artist>();
        }
    }
}