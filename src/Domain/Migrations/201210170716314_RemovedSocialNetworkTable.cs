namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSocialNetworkTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SocialNetworks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SocialNetworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
