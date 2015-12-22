using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DamacanaWebAPI.Models
{
    // A row = 1 single item in a user's cart
    // multiple rows make a complete Cart
    public class Purchase_Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }

        // fields
        [Required]
        public int Amount { get; set; }
        // TODO DateTime timeAdded etc...

        [Required]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public Guid PurchaseId { get; set; }
        //public virtual Purchase Purchase { get; set; } ---> not used and causes self deferencing loops, so I just removed it.
    }
}