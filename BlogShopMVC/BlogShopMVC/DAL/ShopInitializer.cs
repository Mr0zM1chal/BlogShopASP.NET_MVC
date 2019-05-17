using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SklepBlog.Models;

namespace BlogShopMVC.DAL
{
    public class ShopInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            SeedKursyData(context);
            base.Seed(context);
        }

        private void SeedKursyData(ShopContext context)
        {
            var categories = new List<Category>
            {
                new Category (){ CategoryDescription = "Kubki, smycze, wlepy", CategoryId = 2, CategoryName = "Akcesoria", IconFileName = "xyz", },
                new Category (){ CategoryDescription = "Koszulki, koszulki polo", CategoryId = 3, CategoryName = "Koszulki", IconFileName = "xyz", },
                new Category (){ CategoryDescription = "Płyty winyle + blueray", CategoryId = 4, CategoryName = "Płyty", IconFileName = "xyz", },
                new Category (){ CategoryDescription = "Ksiżąki, gazety", CategoryId = 5, CategoryName = "Książki", IconFileName = "xyz", }
            };
            categories.ForEach(k => context.Categories.Add(k));
            context.SaveChanges();
            var products = new List<Product>
            {
                new Product(){ CategoryId = 2, ProductId = 2, ProductMake = "Bloger", ProductModel = "Kubek Szary", ProductPrice = 12.99},
                new Product(){ CategoryId = 2, ProductId = 3, ProductMake = "Bloger", ProductModel = "Kubek Biały", ProductPrice = 12.99},
                new Product(){ CategoryId = 2, ProductId = 4, ProductMake = "Bloger", ProductModel = "Kubek Czarny", ProductPrice = 8.99},
                new Product(){ CategoryId = 3, ProductId = 5, ProductMake = "Bloger", ProductModel = "Koszulka biała", ProductPrice = 44.99},
                new Product(){ CategoryId = 3, ProductId = 6, ProductMake = "Bloger", ProductModel = "Koszulka czarna", ProductPrice = 39.99},
                new Product(){ CategoryId = 3, ProductId = 7, ProductMake = "Bloger", ProductModel = "Koszulka Polo", ProductPrice = 77},
                new Product(){ CategoryId = 4, ProductId = 8, ProductMake = "Bloger", ProductModel = "Płyta z blogami 2019", ProductPrice = 0.99},
                new Product(){ CategoryId = 4, ProductId = 9, ProductMake = "Bloger", ProductModel = "Płyta z blogami 2018", ProductPrice = 2.09},
                new Product(){ CategoryId = 2, ProductId = 10, ProductMake = "Bloger", ProductModel = "Poradnik", ProductPrice = 2.99},
                new Product(){ CategoryId = 2, ProductId = 11, ProductMake = "Bloger", ProductModel = "Przygody blogera", ProductPrice = 22.99},
                new Product(){ CategoryId = 2, ProductId = 12, ProductMake = "Bloger", ProductModel = "Album", ProductPrice = 52.99},
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}