using ExternalApi.Models;
using ExternalApi.Rest;

namespace Api.iTunes
{
    public interface ISearch
    {
        ApiResponse<ITunesSearchResults> Query(string term);
    }

    public class Search : ExternalApiBase, ISearch
    {

        public Search(IExternalApi externalApi):base(externalApi)
        {
        }

        public ApiResponse<ITunesSearchResults> Query(string term)
        {
            var call = Rest.Method(resource: "search").AddParam("term", term);
            return call.Execute<ITunesSearchResults>();
        }
    }
}