//-----------------------------------------------------------------------
// <copyright file="YoutubeApi.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Youtube.Api;

namespace Youtube
{
    /// <summary>
    /// Last.fm API sesspis
    /// </summary>
    public class YoutubeApi : IYoutubeApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeApi"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        public YoutubeApi(IYoutubeConfig config)
        {
            Config = config;
            
            User = new UserApi(this);
            Auth = new AutenticationApi(this);
        }

        /// <summary>
        /// Gets the config.
        /// </summary>
        public IYoutubeConfig Config
        {
            get;
            private set;
        }

        public IAuthenticationApi Auth { get; private set; }

        public IUserApi User
        {
            get;
            private set;
        }
    }
}
