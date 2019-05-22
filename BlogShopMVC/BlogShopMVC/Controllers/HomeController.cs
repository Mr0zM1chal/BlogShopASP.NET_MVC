using BlogShopMVC.DAL;
using BlogShopMVC.ViewModels;
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

            var listCategory = db.Categories.ToList().Take(4);
            var listProduct2 = db.Products.Where(a => a.CategoryId == 2).Take(3).ToList();
            var listProduct3 = db.Products.Where(a => a.CategoryId == 3).Take(3).ToList();

            var vhm = new HomeViewModel()
            {
                Categories = listCategory,
                Products2 = listProduct2,
                Products3 = listProduct3,

            };
            return View(vhm);
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}