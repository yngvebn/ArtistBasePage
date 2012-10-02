namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSignalRConnections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignalRConnections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConnectionId = c.String(),
                        Updated = c.DateTime(nullable: false),
                        UserLogin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserLogins", t => t.UserLogin_Id)
                .Index(t => t.UserLogin_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SignalRConnections", new[] { "UserLogin_Id" });
            DropForeignKey("dbo.SignalRConnections", "UserLogin_Id", "dbo.UserLogins");
            DropTable("dbo.SignalRConnections");
        }
    }
}
