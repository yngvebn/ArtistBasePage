using System;
using System.Collections.ObjectModel;

namespace Domain
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public string Label { get; private set; }
        public DateTime Released { get; private set; }
        public AlbumType AlbumType { get; private set; }
        public virtual Collection<Song> Songs { get; private set; }
    }
}