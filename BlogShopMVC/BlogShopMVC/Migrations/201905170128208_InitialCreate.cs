namespace BlogShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleTitle = c.String(),
                        ArticleShortcut = c.String(),
                        ArticleContent = c.String(),
                        NameOfImageArticle = c.String(),
                        ArticleImportant = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        CategoryDescription = c.String(),
                        IconFileName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductMake = c.String(nullable: false, maxLength: 100),
                        ProductModel = c.String(),
                        ProductPrice = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Address = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 40),
                        Postcode = c.String(nullable: false, maxLength: 6),
                        MobileNumber = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        Comment = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.PositionOfTheOrder",
                c => new
                    {
                        PositionOfTheOrderId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PositionOfTheOrderId)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionOfTheOrder", "ProductId", "dbo.Product");
            DropForeignKey("dbo.PositionOfTheOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.PositionOfTheOrder", new[] { "ProductId" });
            DropIndex("dbo.PositionOfTheOrder", new[] { "OrderId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropTable("dbo.PositionOfTheOrder");
            DropTable("dbo.Order");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            DropTable("dbo.Article");
        }
    }
}
