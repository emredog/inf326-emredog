using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid Id { get; set; }
        public Decimal TotalAmount { get; set; }
        // TODO (last access time, etc...)

        // items in the cart:
        public ICollection<Cart_Product> ProductsInTheCart { get; set; }

        //foreign key
        public Guid UserId { get; set; }
        // navigation property
        public virtual User User { get; set; }
    }
}