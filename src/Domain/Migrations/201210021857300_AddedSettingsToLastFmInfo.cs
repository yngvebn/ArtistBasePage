namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSettingsToLastFmInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LastFmInfoes", "MergeEvents", c => c.Boolean(nullable: true, defaultValue: false));
            AddColumn("dbo.LastFmInfoes", "MergePictures", c => c.Boolean(nullable: true, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LastFmInfoes", "MergePictures");
            DropColumn("dbo.LastFmInfoes", "MergeEvents");
        }
    }
}
