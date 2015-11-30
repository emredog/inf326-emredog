using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaStore.Models
{
    public class Purhcase
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime createdOn { get; set; }
        public KeyValuePair<Product, int> items { get; set; }
        public decimal totalPrice;
    }
}