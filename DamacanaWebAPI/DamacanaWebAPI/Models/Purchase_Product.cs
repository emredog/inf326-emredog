using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DamacanaWebAPI.Models
{
    // A row = 1 single item in a user's cart
    // multiple rows make a complete Cart
    public class Purchase_Product
    {
        public Guid Id { get; set; }

        // fields
        [Required]
        public int Amount { get; set; }
        // TODO DateTime timeAdded etc...


        // foreign keys
        //[Required]
        //public Guid UserId { get; set; }
        //public virtual User User { get; set; }
        [Required]
        Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public Guid PurchaseId { get; set; }
        public virtual Purchase Cart { get; set; }
    }
}