namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSocialNetworks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialNetworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Url = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            DropColumn("dbo.Artists", "Facebook");
            DropColumn("dbo.Artists", "Twitter");
            DropColumn("dbo.Artists", "LinkedIn");
            DropColumn("dbo.Artists", "LastFm");
            DropColumn("dbo.Artists", "GooglePlus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "GooglePlus", c => c.String());
            AddColumn("dbo.Artists", "LastFm", c => c.String());
            AddColumn("dbo.Artists", "LinkedIn", c => c.String());
            AddColumn("dbo.Artists", "Twitter", c => c.String());
            AddColumn("dbo.Artists", "Facebook", c => c.String());
            DropIndex("dbo.SocialNetworks", new[] { "Artist_Id" });
            DropForeignKey("dbo.SocialNetworks", "Artist_Id", "dbo.Artists");
            DropTable("dbo.SocialNetworks");
        }
    }
}
