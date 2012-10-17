using System.Collections.Generic;
using Api.SoundCloud.Models;
using ExternalApi.Models;

namespace Api.SoundCloud.Interfaces
{
    public interface IUsersApi
    {
        ApiResponse<List<User>> Search(string term);
    }
}