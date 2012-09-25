using System;

namespace Domain
{
    public class Song
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime Released { get; private set; }
        public string Writer { get; private set; }
        public string PerformingArtist { get; private set; }
        public TimeSpan SongLength { get; private set; }
    }
}