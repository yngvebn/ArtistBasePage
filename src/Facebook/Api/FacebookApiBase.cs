//-----------------------------------------------------------------------
// <copyright file="FacebookApiBase.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Facebook.Api.Rest;
using RestSharp;

namespace Facebook.Api
{
    /// <summary>
    /// Base class for connecting to Last.fm API
    /// </summary>
    public abstract class FacebookApiBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApiBase"/> class.
        /// </summary>
        /// <param name="api">The session.</param>
        protected FacebookApiBase(IFacebookApi api)
        {
            Api = api;
            Rest = new RestWrapper(Api.Config);
        }

        /// <summary>
        /// Gets the API wrapper.
        /// </summary>
        protected IFacebookApi Api
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

        protected T Get<T>(string objectId) where T: new()
        {
            var call = Rest.Method(objectId, Method.GET).AddParam("access_token", Api.Config.Token);
            return call.Execute<T>();
        }
    }
}
