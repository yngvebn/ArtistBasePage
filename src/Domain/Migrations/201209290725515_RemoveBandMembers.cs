namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBandMembers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BandMembers", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.BandMembers", new[] { "Artist_Id" });
            DropTable("dbo.BandMembers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BandMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.Int(nullable: false),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.BandMembers", "Artist_Id");
            AddForeignKey("dbo.BandMembers", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
