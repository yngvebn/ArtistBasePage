namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeoLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeoLat = c.Double(nullable: false),
                        GeoLong = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "Website", c => c.String());
            AddColumn("dbo.Locations", "City", c => c.String());
            AddColumn("dbo.Locations", "Country", c => c.String());
            AddColumn("dbo.Locations", "Address", c => c.String());
            AddColumn("dbo.Locations", "GeoPoint_Id", c => c.Int());
            AddForeignKey("dbo.Locations", "GeoPoint_Id", "dbo.GeoLocations", "Id");
            CreateIndex("dbo.Locations", "GeoPoint_Id");
            DropColumn("dbo.Events", "End");
            DropColumn("dbo.Locations", "Title");
            DropColumn("dbo.Locations", "Latitude");
            DropColumn("dbo.Locations", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Longitude", c => c.Long(nullable: false));
            AddColumn("dbo.Locations", "Latitude", c => c.Long(nullable: false));
            AddColumn("dbo.Locations", "Title", c => c.String());
            AddColumn("dbo.Events", "End", c => c.DateTime(nullable: false));
            DropIndex("dbo.Locations", new[] { "GeoPoint_Id" });
            DropForeignKey("dbo.Locations", "GeoPoint_Id", "dbo.GeoLocations");
            DropColumn("dbo.Locations", "GeoPoint_Id");
            DropColumn("dbo.Locations", "Address");
            DropColumn("dbo.Locations", "Country");
            DropColumn("dbo.Locations", "City");
            DropColumn("dbo.Events", "Website");
            DropTable("dbo.GeoLocations");
        }
    }
}
