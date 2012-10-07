namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFacebookEventsToArtist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacebookEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacebookId = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FacebookEvents", new[] { "Artist_Id" });
            DropForeignKey("dbo.FacebookEvents", "Artist_Id", "dbo.Artists");
            DropTable("dbo.FacebookEvents");
        }
    }
}
