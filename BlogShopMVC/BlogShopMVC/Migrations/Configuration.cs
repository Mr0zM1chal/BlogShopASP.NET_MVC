namespace BlogShopMVC.Migrations
{
    using BlogShopMVC.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BlogShopMVC.DAL.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlogShopMVC.DAL.ShopContext";
        }

        protected override void Seed(BlogShopMVC.DAL.ShopContext context)
        {
            ShopInitializer.SeedShopData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
