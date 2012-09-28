namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBandMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BandMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BandMembers", new[] { "Artist_Id" });
            DropForeignKey("dbo.BandMembers", "Artist_Id", "dbo.Artists");
            DropTable("dbo.BandMembers");
        }
    }
}
