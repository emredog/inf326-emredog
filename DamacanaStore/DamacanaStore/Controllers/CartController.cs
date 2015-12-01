using DamacanaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DamacanaStore.Controllers
{
    public class CartController : Controller
    {
        public static Cart cart = new Cart()
        {
            id = 1,
            userId = 1,
            totalAmount = (decimal)0.0,
            items = new List<KeyValuePair<Product, int>>()
        };

        // GET: Cart
        public ActionResult Index()
        {
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {

            foreach(Product p in HomeController.products)
                if (p.id == id)
                {
                    KeyValuePair<Product, int> item = new KeyValuePair<Product, int>(p, 1);
                    cart.items.Add(item);
                    cart.totalAmount += p.price;
                    return View("Index", cart);
                }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}