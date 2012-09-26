namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGalleryImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GalleryImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Copyright = c.String(),
                        Photographer = c.String(),
                        InGallery = c.Boolean(nullable: false),
                        DateTaken = c.DateTime(nullable: false),
                        Published = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GalleryImages");
        }
    }
}
