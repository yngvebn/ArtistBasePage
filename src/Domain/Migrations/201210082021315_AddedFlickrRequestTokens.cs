namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFlickrRequestTokens : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlickrInfoes", "RequestToken", c => c.String());
            AddColumn("dbo.FlickrInfoes", "RequestSecret", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlickrInfoes", "RequestSecret");
            DropColumn("dbo.FlickrInfoes", "RequestToken");
        }
    }
}
