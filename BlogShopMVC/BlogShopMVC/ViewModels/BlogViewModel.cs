using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SklepBlog.Models;

namespace BlogShopMVC.ViewModels
{
    public class BlogViewModel
    {
        public IEnumerable<Article> articles { get; set; }
    }
}