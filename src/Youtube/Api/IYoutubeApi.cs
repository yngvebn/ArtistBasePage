//-----------------------------------------------------------------------
// <copyright file="IYoutubeApi.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Youtube.Api
{
    /// <summary>
    /// Last.fm session interface
    /// </summary>
    public interface IYoutubeApi
    {
     

        /// <summary>
        /// Gets the artist API.
        /// </summary>
        IUserApi User
        {
            get;
        }

        /// <summary>
        /// Gets the config of last.fm client.
        /// </summary>
        IYoutubeConfig Config
        {
            get;
        }

        IAuthenticationApi Auth
        {
            get;
        }
    }
}
