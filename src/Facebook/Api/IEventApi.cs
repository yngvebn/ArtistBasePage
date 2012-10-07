//-----------------------------------------------------------------------
// <copyright file="IEventApi.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Facebook.Models;

namespace Facebook.Api
{
    /// <summary>
    /// Last.fm artist API
    /// </summary>
    public interface IEventApi
    {

        Venue GetLocation(string venueId);
        Event GetEvent(string eventId);
    }
}
