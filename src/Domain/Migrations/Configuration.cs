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
            var artist = Artist.Create("yngve.nilsen@gmail.com");
            artist.SetSocialNetwork(SocialNetworkType.Facebook, "http://www.facebook.com/yngve.nilsen");
            artist.SetSocialNetwork(SocialNetworkType.Twitter,  "@yngvenilsen");
            login.AddArtist(artist);

            var arne = Artist.Create("arne@arnevatnoy.com");
            arne.SetSocialNetwork(SocialNetworkType.Twitter,  "@arnevatnoy");
            login.AddArtist(arne);
            context.Artists.AddOrUpdate(a => a.Email,
                                        artist, arne);
            context.UserLogins.AddOrUpdate(a => a.Username,
                                           login);

        }
    }
}
