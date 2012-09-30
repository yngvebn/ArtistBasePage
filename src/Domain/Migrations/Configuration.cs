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
            var artist = Artist.Create("yngve.nilsen@gmail.com");
            artist.SetSocialNetwork(SocialNetworkType.Facebook, "http://www.facebook.com/yngve.nilsen");
            artist.SetSocialNetwork(SocialNetworkType.Twitter,  "@yngvenilsen");
            artist.CreateLogon("yngvebn", "test123");


            var arne = Artist.Create("arne@arnevatnoy.com");
            artist.SetSocialNetwork(SocialNetworkType.Twitter,  "@arnevatnoy");
            context.Artists.AddOrUpdate(a => a.Email,
                                        artist, arne);
        }
    }
}
