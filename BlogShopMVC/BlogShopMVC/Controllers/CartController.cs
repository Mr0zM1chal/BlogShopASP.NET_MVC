using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogShopMVC.App_Start;
using BlogShopMVC.DAL;
using BlogShopMVC.Infrastructure;
using BlogShopMVC.ViewModels;
using SklepBlog.Models;
using System.Linq;
using System.Net;
using System.Web.Providers.Entities;
using Microsoft.AspNetCore.Identity;

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
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Pay(Order detailsOfOrder)
        {

            if (ModelState.IsValid)
            {
                // pobieramy id uzytkownika aktualnie zalogowanego
                var userId = User.Identity.GetUserId();

                // utworzenie obiektu zamowienia na podstawie tego co mamy w koszyku
                var newOrder = cartManager.CreateOrder(detailsOfOrder, userId);
    
            // szczegóły użytkownika - aktualizacja danych 
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.DataUser);
                await UserManager.UpdateAsync(user);

                // opróżnimy nasz koszyk zakupów
                cartManager.EmptyCart();

                return RedirectToAction("OrderCorfirm");
            }
            else
                return View(detailsOfOrder);

        }


        public ActionResult OrderCorfirm()
        {
            return View();
        }
        public async Task<ActionResult> Pay()
        {
            if(Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order()
                {
                    FirstName = user.DataUser.First_Name,
                    LastName = user.DataUser.Last_Name,
                    Adress = user.DataUser.Adress,
                    City = user.DataUser.City,
                    Email = user.DataUser.Email,
                    Mobile = user.DataUser.Mobile,
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnurl = Url.Action("Pay", "Cart") });
            }
        }
    }
    
    }