using BlogShopMVC.DAL;
using SklepBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext db = new ShopContext();
        public ActionResult Index()
        {
            Category category = new Category
            {
                CategoryName = "T-shirt",
                CategoryDescription = "tanie koszulki",
                CategoryId =
                1,
                IconFileName = "xyz",
            };
            db.Categories.Add(category);
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}