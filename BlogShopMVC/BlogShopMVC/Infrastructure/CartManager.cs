using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogShopMVC.DAL;
using BlogShopMVC.Models;
using SklepBlog.Models;

namespace BlogShopMVC.Infrastructure
{
    public class CartManager
    {
        private ISessionManager session;
        private ShopContext db;
        public CartManager(ISessionManager session, ShopContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<PositionOfCart> GetCart()
        {
            List<PositionOfCart> cart;
            if (session.Get<List<PositionOfCart>>(Consts.CartSessionKey) == null)
            {
                cart = new List<PositionOfCart>();
            }
            else
            {
                cart = session.Get<List<PositionOfCart>>(Consts.CartSessionKey) as List<PositionOfCart>;
            }
            return cart;
        }

        public void AddToCart(int productId)
        {
            var cart = GetCart();
            var possition= cart.Find(c => c.product.ProductId == productId);

            if (possition != null)
            {
                possition.quantity++;
            }
            else
            {
                var productToAdd = db.Products.Where(p => p.ProductId == productId).SingleOrDefault();
                if (productToAdd != null)
                {
                    var newPossition = new PositionOfCart()
                    {
                        product = productToAdd,
                        quantity = 1,
                        price = productToAdd.ProductPrice
                    };
                    cart.Add(newPossition);
                }
                
            }
            session.Set(Consts.CartSessionKey, cart);
        }

        public int DeletefromCart(int productId)
        {
            var cart = GetCart();
            var possitionOfCart = cart.Find(c => c.product.ProductId == productId);

            if (possitionOfCart !=null)
            {
                if (possitionOfCart.quantity > 1)
                {
                    possitionOfCart.quantity--;
                    return possitionOfCart.quantity;
                }
                else
                {
                    cart.Remove(possitionOfCart);
                }
            }

            return 0;
        }

        public decimal GetPriceOfCart()
        {
            var cart = GetCart();
            return cart.Sum(c => c.quantity * c.price);
        }

        public int GetquantityPossitionOfcart()
        {
            var cart = GetCart();
            int quantity = cart.Sum(c => c.quantity);
            return quantity;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = GetCart();
            newOrder.OrderDate = DateTime.Now;
            newOrder.UserId = userId;

            db.Orders.Add(newOrder);
            

            if (newOrder.PositionOfTheOrder == null)
            {
                newOrder.PositionOfTheOrder = new List<PositionOfTheOrder>();
            }
            decimal cartPrice = 0;
            foreach (var cartPoss in cart)
            {
                var newPossitionOfOrder = new PositionOfTheOrder()
                {
                    PositionOfTheOrderId = cartPoss.product.ProductId,
                    Quantity = cartPoss.quantity,
                    OrderPrice = cartPoss.product.ProductPrice,
                };

                cartPrice = (cartPoss.quantity * cartPoss.product.ProductPrice);
                newOrder.PositionOfTheOrder.Add(newPossitionOfOrder);
            }
            
            newOrder.Price = cartPrice;
            db.SaveChanges();

            return newOrder;
        }

        public void EmptyCart()
        {
            session.Set<List<PositionOfCart>>(Consts.CartSessionKey, null);
        }
    }
}