using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogShopMVC.DAL;
using BlogShopMVC.ViewModels;

namespace BlogShopMVC.Controllers
{
    public class BlogController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: Blog
        public ActionResult IndexBlog()
        {
            var myArticles = db.Articles.ToList();
            var bvm = new BlogViewModel()
            {
             articles = myArticles
            };
            return View(bvm);
        }
        public ActionResult ArticleDetails(int id)
        {
            var article = db.Articles.Find(id);
            
            return View(article);
        }
    }
}