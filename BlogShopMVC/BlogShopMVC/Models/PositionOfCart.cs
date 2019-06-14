using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SklepBlog.Models;

namespace BlogShopMVC.Models
{
    public class PositionOfCart
    {
        public Product product { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}