namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReferenceFromUserLoginToArtist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserLogins", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.UserLogins", new[] { "Artist_Id" });
            CreateTable(
                "dbo.UserLoginArtists",
                c => new
                    {
                        UserLogin_Id = c.Int(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserLogin_Id, t.Artist_Id })
                .ForeignKey("dbo.UserLogins", t => t.UserLogin_Id, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .Index(t => t.UserLogin_Id)
                .Index(t => t.Artist_Id);
            
            DropColumn("dbo.UserLogins", "Artist_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserLogins", "Artist_Id", c => c.Int());
            DropIndex("dbo.UserLoginArtists", new[] { "Artist_Id" });
            DropIndex("dbo.UserLoginArtists", new[] { "UserLogin_Id" });
            DropForeignKey("dbo.UserLoginArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.UserLoginArtists", "UserLogin_Id", "dbo.UserLogins");
            DropTable("dbo.UserLoginArtists");
            CreateIndex("dbo.UserLogins", "Artist_Id");
            AddForeignKey("dbo.UserLogins", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
