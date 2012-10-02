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
                .ForMember(c => c.UseEvents, opt => opt.MapFrom(d => d.UseEvents))
                .ForMember(c => c.UsePictures, opt => opt.MapFrom(d => d.UsePictures));

            AutoMapper.Mapper.CreateMap<DotLastFm.Models.Image, PictureViewModel>()
                .ForMember(c => c.Url, opt => opt.MapFrom(d => d.Value))
                .ForMember(c => c.Size, opt => opt.ResolveUsing(d => Convert(d.Size)));
        }

        public ImageSize Convert(DotLastFm.Models.ImageSize size)
        {
            switch (size)
            {
                case DotLastFm.Models.ImageSize.Small:
                    return ImageSize.Small;
                    break;
                case DotLastFm.Models.ImageSize.Medium:
                    return ImageSize.Medium;
                    break;
                case DotLastFm.Models.ImageSize.Large:
                    return ImageSize.Large;
                    break;
                case DotLastFm.Models.ImageSize.ExtraLarge:
                    return ImageSize.ExtraLarge;
                    break;
                case DotLastFm.Models.ImageSize.Mega:
                    return ImageSize.Mega;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("size");
            }
        }
    }
}