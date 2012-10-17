namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSocialNetwork : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SocialNetworks", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.SocialNetworks", new[] { "Artist_Id" });
            DropColumn("dbo.SocialNetworks", "Artist_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SocialNetworks", "Artist_Id", c => c.Int());
            CreateIndex("dbo.SocialNetworks", "Artist_Id");
            AddForeignKey("dbo.SocialNetworks", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
