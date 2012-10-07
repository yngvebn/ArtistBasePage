using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace Facebook.Api.Rest
{
    public class FacebookApiException<TModel> : HttpException
    {
        public string Error { get; private set; }
        public FacebookApiException(IRestResponse<TModel> response)
            :base((int)response.StatusCode, "An error occured while communcating with Facebook")
        {
            Error = JsonConvert.DeserializeObject<dynamic>(response.Content).error.message;
        }
    }
}