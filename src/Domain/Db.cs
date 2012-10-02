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
        public DbSet<ApiToken> ApiSessions { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<LastFmInfo> LastFmInfos { get; set; }
        public DbSet<SignalRConnection> SignalRConnections { get; set; }
    }

}