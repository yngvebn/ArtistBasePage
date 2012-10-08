//-----------------------------------------------------------------------
// <copyright file="YoutubeApiBase.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Youtube.Api.Rest;

namespace Youtube.Api
{
    /// <summary>
    /// Base class for connecting to Last.fm API
    /// </summary>
    public abstract class YoutubeApiBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeApiBase"/> class.
        /// </summary>
        /// <param name="api">The session.</param>
        protected YoutubeApiBase(IYoutubeApi api)
        {
            Api = api;
            Rest = new RestWrapper(Api.Config);
        }

        /// <summary>
        /// Gets the API wrapper.
        /// </summary>
        protected IYoutubeApi Api
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the rest provider.
        /// </summary>
        /// <value>
        /// The rest provider.
        /// </value>
        protected RestWrapper Rest
        {
            get;
            set;
        }

    }
}
