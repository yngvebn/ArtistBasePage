//-----------------------------------------------------------------------
// <copyright file="FacebookApi.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Facebook.Api;

namespace Facebook
{
    /// <summary>
    /// Last.fm API sesspis
    /// </summary>
    public class FacebookApi : IFacebookApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApi"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        public FacebookApi(IFacebookConfig config)
        {
            Config = config;
            
            Event = new EventApi(this);
            Auth = new AutenticationApi(this);
        }

        /// <summary>
        /// Gets the config.
        /// </summary>
        public IFacebookConfig Config
        {
            get;
            private set;
        }

        public IAuthenticationApi Auth { get; private set; }

        public void Authenticate()
        {
            throw new System.NotImplementedException();
        }

        public IEventApi Event
        {
            get;
            private set;
        }
    }
}
