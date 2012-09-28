namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsBestOfToAlbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "IsBestOf", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "IsBestOf");
        }
    }
}
