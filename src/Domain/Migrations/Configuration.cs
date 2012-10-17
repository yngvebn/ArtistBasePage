using System.Diagnostics;

namespace Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Db context)
        {
            var login = UserLogin.Create("yngvebn", "test123");
            var artist = Artist.Create("Elisabeth Vatndal");
            login.AddArtist(artist);

            var arne = Artist.Create("Arne Vatnøy");
            login.AddArtist(arne);
            context.Artists.AddOrUpdate(a => a.Name,
                                        artist, arne);
            context.UserLogins.AddOrUpdate(a => a.Username,
                                           login);

        }
    }
}
