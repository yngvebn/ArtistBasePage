using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtistBasePage.Areas.Admin.ViewModels;
using ArtistBasePage.Areas.v1.Controllers;
using ArtistBasePage.Areas.v1.ViewModels;
using Domain;
using Artist = Domain.Artist;

namespace ArtistBasePage.Infrastructure.Mappings
{
    public class ViewModelMappings: IMapping
    {
        public void Setup()
        {
            AutoMapper.Mapper.CreateMap<ApiToken, ApiSessionViewModel>()
                .ForMember(c => c.ArtistId, opt => opt.MapFrom(a => a.AssociatedArtist.Id))
                .ForMember(c => c.Token, opt => opt.MapFrom(f => f.Token));

            AutoMapper.Mapper.CreateMap<Artist, ArtistViewModel>();
            AutoMapper.Mapper.CreateMap<SocialNetwork, SocialNetworkViewModel>();

            AutoMapper.Mapper.CreateMap<Notification, NotificationViewModel>();

            AutoMapper.Mapper.CreateMap<LastFmInfo, LastFmInfoViewModel>()
                .ForMember(c => c.UseBio, opt => opt.MapFrom(d => d.UseBio))
                .ForMember(c => c.UseEvents, opt => opt.MapFrom(d => d.UseEvents));

        }

    }
}