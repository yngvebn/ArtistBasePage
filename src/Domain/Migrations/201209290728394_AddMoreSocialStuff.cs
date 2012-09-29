namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreSocialStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "LinkedIn", c => c.String());
            AddColumn("dbo.Artists", "LastFm", c => c.String());
            AddColumn("dbo.Artists", "GooglePlus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "GooglePlus");
            DropColumn("dbo.Artists", "LastFm");
            DropColumn("dbo.Artists", "LinkedIn");
        }
    }
}
