using System.Collections.Generic;

namespace Api.Spotify.Models
{
    public class ArtistSearchResponse
    {
        public SpotifyResponseInfo Info { get; set; }
        public List<Artist> Artists { get; set; }
    }
}