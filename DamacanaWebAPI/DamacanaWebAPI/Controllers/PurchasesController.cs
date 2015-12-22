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
using System.Collections.ObjectModel;

namespace DamacanaWebAPI.Controllers
{
    public class PurchasesController : ApiController
    {
        private DamacanaWebAPIContext db = new DamacanaWebAPIContext();

        // GET: api/Purchases
        public IQueryable<Purchase> GetPurchases()
        {
            return db.Purchases;
        }

        // GET: api/Purchases/5
        [ResponseType(typeof(Purchase))]
        public async Task<IHttpActionResult> GetPurchase(Guid id)
        {
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }

        // POST: api/Purchases
        [ResponseType(typeof(Purchase))]
        public async Task<IHttpActionResult> PostPurchase(Guid CartId)
        {
            Cart cartToPurchase = db.Carts.Single(c => c.Id == CartId);
            
            // TODO handle case if Cart is not found

            // copy some basic properties
            Purchase purchase = new Purchase();            
            purchase.Id = Guid.NewGuid();
            purchase.CreatedOn = DateTime.Now;
            purchase.UserId = cartToPurchase.UserId;
            purchase.TotalAmount = cartToPurchase.TotalAmount;

            // copy product list
            purchase.PurchasedProducts = new Collection<Purchase_Product>();
            foreach(Cart_Product cp in cartToPurchase.ProductsInTheCart)
            {
                // create a new Purchase_Product object based on a Cart_Product object
                Purchase_Product pp = new Purchase_Product();
                pp.Id = Guid.NewGuid();
                pp.Amount = cp.Amount;
                pp.ProductId = cp.ProductId;
                pp.PurchaseId = purchase.Id;
                purchase.PurchasedProducts.Add(pp);                
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Purchases.Add(purchase);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseExists(purchase.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = purchase.Id }, purchase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseExists(Guid id)
        {
            return db.Purchases.Count(e => e.Id == id) > 0;
        }
    }
}