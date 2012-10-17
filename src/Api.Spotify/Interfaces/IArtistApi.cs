using Api.Spotify.Models;
using ExternalApi.Models;

namespace Api.Spotify.Interfaces
{
    public interface IArtistApi
    {
        ApiResponse<ArtistSearchResponse> Search(string term);
    }
}