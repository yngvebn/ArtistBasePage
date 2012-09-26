namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticlesAndArtists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Password = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Published = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        IsDraft = c.Boolean(nullable: false),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            AddColumn("dbo.Albums", "Artist_Id", c => c.Int());
            AddColumn("dbo.Events", "Artist_Id", c => c.Int());
            AddColumn("dbo.GalleryImages", "Artist_Id", c => c.Int());
            AddForeignKey("dbo.GalleryImages", "Artist_Id", "dbo.Artists", "Id");
            AddForeignKey("dbo.Events", "Artist_Id", "dbo.Artists", "Id");
            AddForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists", "Id");
            CreateIndex("dbo.GalleryImages", "Artist_Id");
            CreateIndex("dbo.Events", "Artist_Id");
            CreateIndex("dbo.Albums", "Artist_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Articles", new[] { "Artist_Id" });
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropIndex("dbo.Events", new[] { "Artist_Id" });
            DropIndex("dbo.GalleryImages", new[] { "Artist_Id" });
            DropForeignKey("dbo.Articles", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Events", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.GalleryImages", "Artist_Id", "dbo.Artists");
            DropColumn("dbo.GalleryImages", "Artist_Id");
            DropColumn("dbo.Events", "Artist_Id");
            DropColumn("dbo.Albums", "Artist_Id");
            DropTable("dbo.Articles");
            DropTable("dbo.Artists");
        }
    }
}
