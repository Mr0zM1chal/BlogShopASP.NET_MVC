using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogShopMVC.DAL;
using BlogShopMVC.Infrastructure;
using BlogShopMVC.ViewModels;
using SklepBlog.Models;

namespace BlogShopMVC.Controllers
{
    public class BlogController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: Blog
        public ActionResult IndexBlog()
        {
            List<Article> myArticles;

            ICacheProvider cache = new DefaultCacheProvider();

            if (cache.isSet(Consts.ArticleCacheKey))
            {
                myArticles = cache.Get(Consts.ArticleCacheKey) as List<Article>;
            }
            else
            {
                myArticles = db.Articles.ToList();
                cache.Set(Consts.ArticleCacheKey, myArticles, 60);
            }
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