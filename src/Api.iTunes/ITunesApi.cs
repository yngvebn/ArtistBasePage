namespace Api.iTunes
{
    public class ITunesApi: ExternalApi.Rest.ExternalApi, IITunesApi
    {
        public ITunesApi(ITunesConfig config): base(config)
        {
            Search = new Search(this);
        }

        public ISearch Search { get; private set; }
    }
}