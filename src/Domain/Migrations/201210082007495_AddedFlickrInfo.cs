namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFlickrInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlickrInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsConnected = c.Boolean(nullable: false),
                        Token = c.String(),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FlickrInfoes", new[] { "Id" });
            DropForeignKey("dbo.FlickrInfoes", "Id", "dbo.Artists");
            DropTable("dbo.FlickrInfoes");
        }
    }
}
