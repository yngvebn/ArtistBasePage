namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBandMemberRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BandMembers", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BandMembers", "Role");
        }
    }
}
