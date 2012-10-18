using System.Collections.Generic;

namespace Gateway.Interfaces
{
    public interface IExternalApiGateway
    {
        List<ExternalApiUser> SearchExternalApis(string term);
    }
}