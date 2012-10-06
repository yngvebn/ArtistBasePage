//-----------------------------------------------------------------------
// <copyright file="IFacebookApi.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Facebook.Api
{
    /// <summary>
    /// Last.fm session interface
    /// </summary>
    public interface IFacebookApi
    {
     

        /// <summary>
        /// Gets the artist API.
        /// </summary>
        IEventApi Event
        {
            get;
        }

        /// <summary>
        /// Gets the config of last.fm client.
        /// </summary>
        IFacebookConfig Config
        {
            get;
        }
    }
}
