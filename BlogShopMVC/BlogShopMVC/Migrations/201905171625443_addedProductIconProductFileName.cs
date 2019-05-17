namespace BlogShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProductIconProductFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "IconProductFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "IconProductFileName");
        }
    }
}
