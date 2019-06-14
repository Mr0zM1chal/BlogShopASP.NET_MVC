using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogShopMVC.Models;

namespace BlogShopMVC.ViewModels
{
    public class CartViewModel
    {
        public List<PositionOfCart> PossitionsOfCart { get; set; }
        public decimal AllPrice{ get; set; }
    }
}