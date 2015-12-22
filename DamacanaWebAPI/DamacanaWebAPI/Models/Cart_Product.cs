using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    // A row = 1 single item in a user's cart
    // multiple rows make a complete Cart
    public class Cart_Product
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
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }

        
    }
}