using SklepBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogShopMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories{get; set;} 
        public IEnumerable<Product> Products2{get; set;} 
        public IEnumerable<Product> Products3{get; set;} 
    
    }
}