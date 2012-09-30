namespace ArtistBasePage.Infrastructure
{
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