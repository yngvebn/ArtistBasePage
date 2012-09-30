namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            DropColumn("dbo.Artists", "Username");
            DropColumn("dbo.Artists", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Password", c => c.String());
            AddColumn("dbo.Artists", "Username", c => c.String());
            DropIndex("dbo.UserLogins", new[] { "Artist_Id" });
            DropForeignKey("dbo.UserLogins", "Artist_Id", "dbo.Artists");
            DropTable("dbo.UserLogins");
        }
    }
}
