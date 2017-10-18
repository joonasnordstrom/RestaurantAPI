namespace RestaurantAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedImagePathFromDishes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dishes", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dishes", "ImagePath", c => c.String());
        }
    }
}
