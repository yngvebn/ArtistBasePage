//-----------------------------------------------------------------------
// <copyright file="UserApi.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Youtube.Models;
using Youtube.Api.Rest;

namespace Youtube.Api
{
    /// <summary>
    /// Last.fm artist API
    /// </summary>
    public class UserApi : YoutubeApiBase, IUserApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class.
        /// </summary>
        /// <param name="api">The API wrapper.</param>
        public UserApi(IYoutubeApi api)
            : base(api)
        {
        }


        public UserFeed GetUserFeed(string userId)
        {
            var call = Rest.Method(string.Format("users/{0}/uploads", userId));
            return call.Execute<UserFeed>();
        }
    }
}
