using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Decimal Price { get; set; }
        // TODO
    }
}