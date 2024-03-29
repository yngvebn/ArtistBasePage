﻿using System;
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

            AutoMapper.Mapper.CreateMap<Notification, NotificationViewModel>();

            AutoMapper.Mapper.CreateMap<LastFmInfo, LastFmInfoViewModel>()
                .ForMember(c => c.UseBio, opt => opt.MapFrom(d => d.UseBio))
                .ForMember(c => c.UseEvents, opt => opt.MapFrom(d => d.UseEvents));

            AutoMapper.Mapper.CreateMap<DotLastFm.Models.Event, EventViewModel>()
                .ForMember(c => c.Title, opt => opt.MapFrom(m => m.Title))
                .ForMember(c => c.StartTime, opt => opt.MapFrom(m => m.StartDate))
                .ForMember(c => c.Location, opt => opt.MapFrom(m => m.Venue.Name))
                .ForMember(c => c.Source, opt => opt.UseValue(EventOrigin.LastFm));


            AutoMapper.Mapper.CreateMap<Facebook.Models.Event, EventViewModel>()
                .ForMember(c => c.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(c => c.Title, opt => opt.MapFrom(m => m.Name))
                .ForMember(c => c.Location, opt => opt.MapFrom(m => m.Location))
                .ForMember(c => c.StartTime, opt => opt.MapFrom(m => m.Start_Time.ToLocalTime(TimeZones.PacificStandardTime)))
                .ForMember(c => c.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(c => c.Source, opt => opt.UseValue(EventOrigin.Facebook));


            AutoMapper.Mapper.CreateMap<Domain.Event, EventViewModel>()
                .ForMember(c => c.Title, opt => opt.MapFrom(m => m.Title))
                .ForMember(c => c.Source, opt => opt.UseValue(EventOrigin.Site));
        }

    }
}