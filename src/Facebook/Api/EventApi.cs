//-----------------------------------------------------------------------
// <copyright file="EventApi.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Facebook.Api.Rest;
using Facebook.Models;
using RestSharp;

namespace Facebook.Api
{
    /// <summary>
    /// Last.fm artist API
    /// </summary>
    public class EventApi : FacebookApiBase, IEventApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventApi"/> class.
        /// </summary>
        /// <param name="api">The API wrapper.</param>
        public EventApi(IFacebookApi api)
            : base(api)
        {
        }

        public Event GetEvent(string eventId)
        {
            var call = Rest.Method(eventId, Method.GET).AddParam("access_token", Api.Config.Token);
                
                           
            var ev = call.Execute<Event>();
            return ev;
        }

    }
}
