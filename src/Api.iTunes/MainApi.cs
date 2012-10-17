using Api.iTunes.Interfaces;

namespace Api.iTunes
{
    public class MainApi: ExternalApi.Rest.ExternalApi, IITunesApi
    {
        public MainApi(ITunesConfig config): base(config)
        {
            Search = new Search(this);
        }

        public ISearch Search { get; private set; }
    }
}