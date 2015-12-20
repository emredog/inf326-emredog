using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        // TODO
    }
}