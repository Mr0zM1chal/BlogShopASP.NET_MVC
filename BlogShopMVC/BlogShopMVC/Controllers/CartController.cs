using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogShopMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Koszyk
        public ActionResult Index()
        {
            return View();
        }
    }
}