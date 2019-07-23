namespace BlogShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DataUser_PostCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DataUser_PostCode");
        }
    }
}
