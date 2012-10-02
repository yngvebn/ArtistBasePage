using DotLastFm.Api;

namespace ArtistBasePage.Infrastructure.LastFm
{
    public class LastFmConfig: ILastFmConfig
    {
        public LastFmConfig()
        {
            ApiKey = "e827a3df96fe6354f8560af432d803a3";
            Secret = "b98a501206bf04bf7306301ab6bacf8a";
            BaseUrl ="http://ws.audioscrobbler.com/2.0";
        }

        public string BaseUrl { get; private set; }
        public string ApiKey { get; private set; }
        public string Secret { get; private set; }
    }
}