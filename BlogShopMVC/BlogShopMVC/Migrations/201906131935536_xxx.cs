namespace BlogShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ProductPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Order", "UserId");
        }
    }
}
