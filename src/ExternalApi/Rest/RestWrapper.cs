//-----------------------------------------------------------------------
// <copyright file="RestWrapper.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net;
using ExternalApi.Models;
using RestSharp;
using RestSharp.Deserializers;

namespace ExternalApi.Rest
{
    /// <summary>
    /// Rest wrapper for simple calling
    /// </summary>
    public class RestWrapper
    {
        /// <summary>
        /// Last.fm configuration
        /// </summary>
        private readonly IApiConfig config;

        /// <summary>
        /// Rest client
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestWrapper"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        public RestWrapper(IApiConfig config)
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
                    client.ClearHandlers();
                    if (config.DataType == ApiDataType.Xml)
                        client.AddHandler("*", new XmlAttributeDeserializer());

                    foreach (var parameter in config.DefaultParameters)
                        client.DefaultParameters.Add(parameter);
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
        public ApiResponse<TModel> Execute<TModel>(string method, string resource = null, params Parameter[] parameters) where TModel : new()
        {
            var request = new RestRequest(resource ?? "", Method.GET);

            request.AddParameter("method", method, ParameterType.GetOrPost);
            foreach (var p in parameters)
            {
                request.AddParameter(p);
            }
                
            var responseObject = Client.Execute(request);
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<TModel>(responseObject.Content);

            if (responseObject.StatusCode != HttpStatusCode.OK)
            {
                return ApiResponse<TModel>.Fail(new WebException(string.Format("API has returned {0} HTTP error: {1}", (int)responseObject.StatusCode, responseObject.ErrorMessage)));
            }

            if (response == null)
            {
                return ApiResponse<TModel>.Fail(new InvalidOperationException("Response cannot get data."));
            }

            return ApiResponse<TModel>.Success(response);
        }
    }
}
