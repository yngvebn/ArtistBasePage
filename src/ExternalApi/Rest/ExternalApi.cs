using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalApi.Rest
{
    public abstract class ExternalApi: IExternalApi
    {
        protected ExternalApi(IApiConfig config)
        {
            Config = config;
        }

        public IApiConfig Config { get; private set; }
    }
}
