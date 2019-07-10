using BlogShopMVC.DAL;
using BlogShopMVC.Infrastructure;
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

            List<Category> listCategory;
            List<Product> listProduct2;
            List<Product> listProduct3;





            
            ICacheProvider cache = new DefaultCacheProvider();
            if (cache.isSet(Consts.listCategoryCacheKey))
            {
                listCategory = cache.Get(Consts.listCategoryCacheKey) as List<Category>;
            }
            else
            {
                listCategory = db.Categories.ToList();
                cache.Set(Consts.listCategoryCacheKey, listCategory, 60);
            }
            if (cache.isSet(Consts.listProduct2CacheKey))
            {
                listProduct2 = cache.Get(Consts.listProduct2CacheKey) as List<Product>;
            }
            else
            {
                listProduct2 = db.Products.Where(a => a.CategoryId == 2).Take(3).ToList();
                cache.Set(Consts.listProduct2CacheKey, listProduct2, 60);
            }
            if (cache.isSet(Consts.listProduct3CacheKey))
            {
                listProduct3 = cache.Get(Consts.listProduct3CacheKey) as List<Product>;
            }
            else
            {
                listProduct3 = db.Products.Where(a => a.CategoryId == 3).Take(3).ToList();
                cache.Set(Consts.listProduct3CacheKey, listProduct3, 60);
            }
             
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