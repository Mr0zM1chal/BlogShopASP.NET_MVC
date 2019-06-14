using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogShopMVC.DAL;
using BlogShopMVC.Infrastructure;
using BlogShopMVC.ViewModels;

namespace BlogShopMVC.Controllers
{
    public class CartController : Controller
    {
        private CartManager cartManager;
        private ISessionManager sessionManager;
        private ShopContext db;

        public CartController()
        {
            db = new ShopContext();
            sessionManager = new SessionManager();
            cartManager = new CartManager(sessionManager, db);
        }
        // GET: Cart
        public ActionResult Index()
        {
            var possitionsCart = cartManager.GetCart();
            var priceCart = cartManager.GetPriceOfCart();
            CartViewModel cvm = new CartViewModel()
            {
                PossitionsOfCart = possitionsCart,
                AllPrice = priceCart
            };  
            return View(cvm);
        }

        public ActionResult AddToCart(int id)
        {
            cartManager.AddToCart(id);
            return RedirectToAction("Index");
        }

        public int GetQuantityOFcart()
        {
            return cartManager.GetquantityPossitionOfcart();
        }

        public ActionResult DeleteFromCart(int productId)
        {
            return View();
        }
    }
}