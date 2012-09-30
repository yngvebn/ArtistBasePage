using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistBasePage.Infrastructure
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source) where TDestination : class;
        TDestination Map<TDestination>(object source) where TDestination : class;
    }

    public class Mapper: IMapper
    {
        public TDestination Map<TDestination, TSource>(TSource source)
            where TDestination: class
        {
            return AutoMapper.Mapper.Map<TSource>(source) as TDestination;
        }

        

        public TDestination Map<TDestination>(object source)
            where TDestination : class
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}