using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogShopMVC.DAL;
using MvcSiteMapProvider;
using SklepBlog.Models;

namespace BlogShopMVC.Infrastructure
{
    public class CategoriesDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ShopContext db = new ShopContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Category category in db.Categories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = category.CategoryName;
                node.Key = "Kategoria " + category.CategoryId;
                node.RouteValues.Add("categoryName", category.CategoryName);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}