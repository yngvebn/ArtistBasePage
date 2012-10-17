using Api.iTunes.Interfaces;
using Api.iTunes.Models;
using ExternalApi.Models;
using ExternalApi.Rest;

namespace Api.iTunes
{
    public class Search : ExternalApiBase, ISearch
    {

        public Search(IExternalApi externalApi):base(externalApi)
        {
        }

        public ApiResponse<SearchResponse> Query(string term)
        {
            var call = Rest.Method(resource: "search.json").AddParam("term", term);
            return call.Execute<SearchResponse>();
        }
    }
}