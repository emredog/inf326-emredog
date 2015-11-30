using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaStore.Models
{
    public class Cart
    {
        public int id { get; set; }
        public int userId { get; set; }
        public KeyValuePair<Product, int> items { get; set; }
    }
}