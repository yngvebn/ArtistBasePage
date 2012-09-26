using System.Data.Entity;

namespace Domain
{
    public class Db: DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
    }
}