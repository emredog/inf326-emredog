using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Decimal TotalAmount { get; set; }
        // TODO (last access time, etc...)

        // items in the cart:
        public ICollection<Cart_Product> ProductsInTheCart { get; set; }

        //foreign key
        public Guid UserId { get; set; }
        // navigation property
        public User User { get; set; }
    }
}