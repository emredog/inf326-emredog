using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DamacanaWebAPI.Models;

namespace DamacanaWebAPI.Controllers
{
    public class CartsController : ApiController
    {
        private DamacanaWebAPIContext db = new DamacanaWebAPIContext();

        // GET: api/Carts
        public IQueryable<CartDTO> GetCarts()
        {
            var carts = from c in db.Carts
                        select new CartDTO()
                        {
                            Id = c.Id,
                            UserName = c.User.Name + " " + c.User.Surname,
                            TotalAmount = c.TotalAmount                            
                        };

            return carts;
        }

        // GET: api/Carts/5
        [ResponseType(typeof(CartDetailsDTO_Retrieve))]
        public async Task<IHttpActionResult> GetCart(Guid id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            CartDetailsDTO_Retrieve cartDetails = new CartDetailsDTO_Retrieve();
            cartDetails.Id = cart.Id;            
            cartDetails.TotalAmount = cart.TotalAmount;
            cartDetails.UserName = cart.User.Name + " " + cart.User.Surname;
            cartDetails.ProductsInCart = new List<KeyValuePair<Product, int>>();
            // prepare products in the cart
            foreach (Cart_Product cp in cart.ProductsInTheCart)
            {
                KeyValuePair<Product, int> kvp = new KeyValuePair<Product, int>(cp.Product, cp.Amount);
                cartDetails.ProductsInCart.Add(kvp);
            }

            return Ok(cartDetails);
        }


        // ADD PRODUCTS TO A EXISTING CART HERE ------s
        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCart(Guid id, CartDetailsDTO cartDto)
        {

            Cart cartToBeModfied = db.Carts.Single(a => a.Id == id);

            cartToBeModfied.LastModified = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartDto.Id)
            {
                return BadRequest();
            }

            //copy CartDTO to Cart object
            cartToBeModfied.ProductsInTheCart = cartDto.ProductsInTheCart;

            // drop all products in the cart_products related to this cart
            db.CartProducts.RemoveRange(db.CartProducts.Where(x => x.CartId == cartToBeModfied.Id));

            // Cart_Products already has the ProductId and the CartId, just generate their own id's
            foreach (Cart_Product cp in cartToBeModfied.ProductsInTheCart)
                cp.Id = Guid.NewGuid();

            //and insert them into the dbcontext object
            db.CartProducts.AddRange(cartToBeModfied.ProductsInTheCart);

            // calculate total amount
            cartToBeModfied.TotalAmount = this.CalculateTotalAmount(cartToBeModfied);
            
            db.Entry(cartToBeModfied).State = EntityState.Modified;

            try // and save changes to the actual db
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // ------ CREATE A NEW CART HERE ------------
        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> PostCart(Cart cart)
        {
            if (cart.Id == Guid.Empty) // if no guid is provided
                cart.Id = Guid.NewGuid(); // generates an ID for the newly created Cart object

            cart.CreatedOn = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(cart);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateEx)
            {
                Console.WriteLine(dbUpdateEx.Message);
                if (CartExists(cart.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cart.Id }, cart);
        }


        protected Decimal CalculateTotalAmount(Cart cart)
        {
            Decimal totalAmount = (Decimal)0.0;

            foreach (Cart_Product cp in cart.ProductsInTheCart)
            {
                Product p = db.Products.Single(a => a.Id == cp.ProductId);
                totalAmount += p.Price * cp.Amount;
            }

            return totalAmount;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(Guid id)
        {
            return db.Carts.Count(e => e.Id == id) > 0;
        }
    }
}