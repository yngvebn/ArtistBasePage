using Api.iTunes.Models;
using ExternalApi.Models;

namespace Api.iTunes.Interfaces
{
    public interface ISearch
    {
        ApiResponse<SearchResponse> Query(string term);
    }
}