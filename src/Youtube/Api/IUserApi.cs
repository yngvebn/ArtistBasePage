//-----------------------------------------------------------------------
// <copyright file="IUserApi.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Youtube.Models;

namespace Youtube.Api
{
    /// <summary>
    /// Last.fm artist API
    /// </summary>
    public interface IUserApi
    {

        UserFeed GetUserFeed(string userId);
    }
}
