using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    // This class is used for GET (retrieve) endpoint
    public class CartDetailsDTO_GET
    {
        public Guid Id { get; set; }
        // TODO add more properties as necessary
        public String UserName { get; set; }

        public Decimal TotalAmount { get; set; }
        
        public List<KeyValuePair<Product, int>> ProductsInCart { get; set; }
    }

    // This class is used when adding a new product to the cart (PUT endpoint)
    public class CartDetailsDTO_PUT
    {
        public Guid Id { get; set; }
        // TODO add more properties as necessary
        public String UserName { get; set; }

        public Decimal TotalAmount { get; set; }

        //navigation property
        public virtual ICollection<Cart_Product> ProductsInTheCart { get; set; }

        //foreign key
        public Guid UserId { get; set; }
        // navigation property
        public virtual User User { get; set; }
    }
}