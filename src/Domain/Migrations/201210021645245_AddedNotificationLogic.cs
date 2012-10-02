namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotificationLogic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "CancelText", c => c.String());
            AddColumn("dbo.Notifications", "AcceptAction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "AcceptAction");
            DropColumn("dbo.Notifications", "CancelText");
        }
    }
}
