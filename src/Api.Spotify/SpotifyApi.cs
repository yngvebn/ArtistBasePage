using Api.Spotify.Interfaces;

namespace Api.Spotify
{
    public class SpotifyApi: ExternalApi.Rest.ExternalApi, ISpotifyApi
    {
        public SpotifyApi(ISpotifyApiConfig config): base(config)
        {
            Artist = new ArtistApi(this);
        }

        public IArtistApi Artist { get; private set; }
    }
}