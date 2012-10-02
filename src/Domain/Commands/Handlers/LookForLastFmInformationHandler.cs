using Domain.Events;
using DotLastFm.Api;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Commands.Handlers
{
    public class LookForLastFmInformationHandler: IHandleCommand<LookForLastFmInformation>
    {
        private readonly ILastFmApi _lastFmApi;

        public LookForLastFmInformationHandler(ILastFmApi lastFmApi)
        {
            _lastFmApi = lastFmApi;
        }

        public void Handle(LookForLastFmInformation command)
        {
            var lastFmInfo = _lastFmApi.Artist.GetInfo(command.Artist.Name);
            if(lastFmInfo != null)
            {
                DomainEvents.Raise(new LastFmInfoFound()
                                       {
                                           Artist = command.Artist,
                                           LastFmArtist = lastFmInfo
                                       });
            }
        }
    }
}