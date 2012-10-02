namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLastFmInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LastFmInfoes", "UseEvents", c => c.Boolean(nullable: false));
            AddColumn("dbo.LastFmInfoes", "UsePictures", c => c.Boolean(nullable: false));
            AddColumn("dbo.LastFmInfoes", "UseBio", c => c.Boolean(nullable: false));
            DropColumn("dbo.LastFmInfoes", "MergeEvents");
            DropColumn("dbo.LastFmInfoes", "MergePictures");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LastFmInfoes", "MergePictures", c => c.Boolean(nullable: false));
            AddColumn("dbo.LastFmInfoes", "MergeEvents", c => c.Boolean(nullable: false));
            DropColumn("dbo.LastFmInfoes", "UseBio");
            DropColumn("dbo.LastFmInfoes", "UsePictures");
            DropColumn("dbo.LastFmInfoes", "UseEvents");
        }
    }
}
