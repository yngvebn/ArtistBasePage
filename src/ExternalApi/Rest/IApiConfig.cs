using System.Collections.Generic;
using RestSharp;

namespace ExternalApi.Rest
{
    public interface IApiConfig
    {
        ApiDataType DataType { get; }
        string BaseUrl { get; set; }
        IEnumerable<Parameter> DefaultParameters { get; }
    }
}