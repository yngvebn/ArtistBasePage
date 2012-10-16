using RestSharp;

namespace ExternalApi.Rest
{
    public class ExternalApiBase
    {
        protected ExternalApiBase(IExternalApi api)
        {
            Api = api;
            Rest = new RestWrapper(Api.Config);
        }

        protected IExternalApi Api
        {
            get;
            private set;
        }

        protected RestWrapper Rest
        {
            get;
            set;
        }

    }
}