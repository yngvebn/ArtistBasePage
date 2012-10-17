using System.Collections.Generic;
using Api.SoundCloud.Interfaces;
using Api.SoundCloud.Models;
using ExternalApi.Models;
using ExternalApi.Rest;

namespace Api.SoundCloud
{
    public class Users : ExternalApiBase, IUsersApi
    {
        public Users(IExternalApi soundCloudApi):base(soundCloudApi)
        {
        }

        public ApiResponse<List<User>> Search(string term)
        {
            var call = Rest.Method(resource: "users.json").AddParam("q", term);
            return call.Execute<List<User>>();  
        }
    }
}