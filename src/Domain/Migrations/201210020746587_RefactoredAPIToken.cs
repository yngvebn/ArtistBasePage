namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredAPIToken : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApiSessions", "AuthenticatedArtist_Id", "dbo.Artists");
            DropIndex("dbo.ApiSessions", new[] { "AuthenticatedArtist_Id" });
            CreateTable(
                "dbo.ApiTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Expires = c.DateTime(nullable: false),
                        Token = c.String(),
                        CorrelationId = c.Guid(nullable: false),
                        IsAuthenticated = c.Boolean(nullable: false),
                        AssociatedArtist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.AssociatedArtist_Id)
                .Index(t => t.AssociatedArtist_Id);
            
            DropTable("dbo.ApiSessions");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.ApiTokens", new[] { "AssociatedArtist_Id" });
            DropForeignKey("dbo.ApiTokens", "AssociatedArtist_Id", "dbo.Artists");
            DropTable("dbo.ApiTokens");
            CreateIndex("dbo.ApiSessions", "AuthenticatedArtist_Id");
            AddForeignKey("dbo.ApiSessions", "AuthenticatedArtist_Id", "dbo.Artists", "Id");
        }
    }
}
