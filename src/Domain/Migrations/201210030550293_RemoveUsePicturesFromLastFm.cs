namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUsePicturesFromLastFm : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LastFmInfoes", "UsePictures");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LastFmInfoes", "UsePictures", c => c.Boolean(nullable: false));
        }
    }
}
