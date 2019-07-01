using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using BlogShopMVC.DAL;
using MvcSiteMapProvider;
using SklepBlog.Models;

namespace BlogShopMVC.Infrastructure
{
    public class ShopContentDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ShopContext db = new ShopContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Product product in db.Products)
            {
                DynamicNode node = new DynamicNode();
                node.Title = product.ProductModel;
                node.Key = "Produkt " + product.ProductModel;
                node.ParentKey = "Kategoria " + product.CategoryId;
                node.RouteValues.Add("id", product.ProductId);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}