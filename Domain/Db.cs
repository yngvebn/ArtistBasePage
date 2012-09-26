using System.Collections.Generic;
using System.Data.Entity;

namespace Domain
{
    public class Db: DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ApiSession> ApiSessions { get; set; }
    }
}