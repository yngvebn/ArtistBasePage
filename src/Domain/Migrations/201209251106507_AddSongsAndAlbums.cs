namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSongsAndAlbums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Released = c.DateTime(nullable: false),
                        Writer = c.String(),
                        PerformingArtist = c.String(),
                        SongLength = c.Time(nullable: false),
                        Album_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Artist = c.String(),
                        Label = c.String(),
                        Released = c.DateTime(nullable: false),
                        AlbumType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropTable("dbo.Albums");
            DropTable("dbo.Songs");
        }
    }
}
