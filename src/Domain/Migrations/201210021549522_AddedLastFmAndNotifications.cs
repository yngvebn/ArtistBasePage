namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLastFmAndNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Type = c.Int(nullable: false),
                        Read = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.LastFmInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsConnected = c.Boolean(nullable: false),
                        Bio = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.LastFmInfoes", new[] { "Id" });
            DropIndex("dbo.Notifications", new[] { "Artist_Id" });
            DropForeignKey("dbo.LastFmInfoes", "Id", "dbo.Artists");
            DropForeignKey("dbo.Notifications", "Artist_Id", "dbo.Artists");
            DropTable("dbo.LastFmInfoes");
            DropTable("dbo.Notifications");
        }
    }
}
