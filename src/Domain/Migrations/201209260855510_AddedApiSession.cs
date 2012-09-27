namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApiSession : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Expires = c.DateTime(nullable: false),
                        Token = c.String(),
                        Read = c.Boolean(nullable: false),
                        Write = c.Boolean(nullable: false),
                        AuthenticatedArtist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.AuthenticatedArtist_Id)
                .Index(t => t.AuthenticatedArtist_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ApiSessions", new[] { "AuthenticatedArtist_Id" });
            DropForeignKey("dbo.ApiSessions", "AuthenticatedArtist_Id", "dbo.Artists");
            DropTable("dbo.ApiSessions");
        }
    }
}
