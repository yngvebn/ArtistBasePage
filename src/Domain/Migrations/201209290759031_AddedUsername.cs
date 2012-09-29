namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUsername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Username");
        }
    }
}
