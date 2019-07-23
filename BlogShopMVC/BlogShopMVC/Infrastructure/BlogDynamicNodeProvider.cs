using BlogShopMVC.DAL;
using MvcSiteMapProvider;
using SklepBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogShopMVC.Infrastructure
{
    public class BlogDynamicNodeProvider : DynamicNodeProviderBase

    {
        private ShopContext db = new ShopContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Article article in db.Articles)
            {
                DynamicNode node = new DynamicNode();
                node.Title = article.ArticleTitle;
                node.Key = "Wpis " + article.ArticleTitle;
                node.RouteValues.Add("id", article.ArticleId);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}