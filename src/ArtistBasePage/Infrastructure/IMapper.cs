using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistBasePage.Infrastructure
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source);
        TDestination Map<TDestination>(object source);
    }
}