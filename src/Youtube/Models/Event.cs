using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Youtube.Models
{

    [DeserializeAs(Name="feed")]
    public class UserFeed
    {
        [DeserializeAs(Name = "entry")]
        public List<Entry> Entries { get; set; }
    }

    public class Entry
    {
        public string Title { get; set; }
    }
}