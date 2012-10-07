//-----------------------------------------------------------------------
// <copyright file="RestWrapper.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net;
using RestSharp;

namespace Facebook.Api.Rest
{
    /// <summary>
    /// Rest wrapper for simple calling
    /// </summary>
    public class RestWrapper
    {
        /// <summary>
        /// Last.fm configuration
        /// </summary>
        private readonly IFacebookConfig config;

        /// <summary>
        /// Rest client
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestWrapper"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        public RestWrapper(IFacebookConfig config)
        {
            this.config = config;
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        protected virtual RestClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new RestClient(config.BaseUrl);
                }

                return client;
            }
        }

        /// <summary>
        /// Executes the specified method.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Created model</returns>
        public TModel Execute<TModel>(string method, Method type, params Parameter[] parameters) where TModel : new()
        {
            var request = new RestRequest(method, type);

            //request.AddParameter("method", method, ParameterType.UrlSegment);
            foreach (var p in parameters)
            {
                request.AddParameter(p);
            }

            var response = Client.Execute<TModel>(request);

            
            return response.Data;
        }

        /// <summary>
        /// Executes the specified method.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Created model</returns>
        public string Execute(string method, Method type, params Parameter[] parameters)
        {
            var request = new RestRequest(method, type);

            //request.AddParameter("method", method, ParameterType.UrlSegment);
            foreach (var p in parameters)
            {
                request.AddParameter(p);
            }

            var response = Client.Execute(request);

            return response.Content;
        }
    }
}
