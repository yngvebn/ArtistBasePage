using System.Data.Entity;

namespace Domain
{
    public class Db: DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}