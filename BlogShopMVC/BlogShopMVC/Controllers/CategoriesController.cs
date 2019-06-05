using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogShopMVC.DAL;

namespace BlogShopMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string categoryName)
        {
            var category = db.Categories.Include("Products").Where(c => c.CategoryName.ToUpper() == categoryName.ToUpper()).Single();
            var products = db.Products.Where(p => p.CategoryId == category.CategoryId).ToList();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoriesMenu", categories);
        }
    }
}