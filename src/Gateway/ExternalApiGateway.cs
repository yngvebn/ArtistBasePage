using System.Collections.Generic;

namespace Gateway
{
    public interface IExternalApiGateway
    {
        List<ExternalApiUser> SearchExternalApis(string term);

    }
}