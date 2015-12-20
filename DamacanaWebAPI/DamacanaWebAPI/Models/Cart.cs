using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public List<KeyValuePair<Product, int>> ProductsAndAmounts { get; set; }
        public Decimal TotalAmount { get; set; }
        // TODO (last access time, etc...)

        //foreign key
        public Guid UserId;
        // navigation property
        public User User;
    }
}