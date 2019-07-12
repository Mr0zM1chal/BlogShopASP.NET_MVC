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
        public ActionResult List(string categoryName, string searchQuery = null)
        {
            var category = db.Categories.Include("Products").Where(c => c.CategoryName.ToUpper() == categoryName.ToUpper()).Single();
            var products = category.Products.Where(a => searchQuery == null
             || a.ProductModel.ToLower().Contains(searchQuery.ToLower()));
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductsList", products);
            }
            return View(products);
        }
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoriesMenu", categories);
        }
        public ActionResult ProductsHinits(string term)
        {
            var productsXYZ = db.Products.Where(a => a.ProductModel.ToLower().Contains(term.ToLower())).Take(5)
                .Select(a => new { label = a.ProductModel });
            return Json(productsXYZ, JsonRequestBehavior.AllowGet);
        }
    }
}