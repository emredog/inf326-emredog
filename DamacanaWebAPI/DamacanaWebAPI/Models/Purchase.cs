using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public List<KeyValuePair<Product, int>> ProductsAndAmounts { get; set; }
        [Required]
        public Decimal TotalAmount { get; set; }
        [Required]
        public DateTime CreatedOn;
        // TODO (last access time, etc...)

        //foreign key
        public Guid UserId;
        // navigation property
        public User User;
    }
}