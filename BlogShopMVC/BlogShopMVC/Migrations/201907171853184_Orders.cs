namespace BlogShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Order", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Order", "UserId");
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "UserId");
            AddColumn("dbo.Order", "Adress", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Order", "Mobile", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Order", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Order", "UserId");
            DropColumn("dbo.Order", "Address");
            DropColumn("dbo.Order", "MobileNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "MobileNumber", c => c.String());
            AddColumn("dbo.Order", "Address", c => c.String(nullable: false, maxLength: 100));
            DropIndex("dbo.Order", new[] { "UserId" });
            AlterColumn("dbo.Order", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "Mobile");
            DropColumn("dbo.Order", "Adress");
            RenameColumn(table: "dbo.Order", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Order", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "ApplicationUser_Id");
        }
    }
}
