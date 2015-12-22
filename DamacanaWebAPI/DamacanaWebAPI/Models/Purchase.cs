using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }
        [Required]
        public Decimal TotalAmount { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        // TODO (last access time, etc...)

        public ICollection<Purchase_Product> PurchasedProducts { get; set;  }


        //foreign key
        public Guid UserId { get; set; }
        // navigation property
        public virtual User User { get; set; }
    }
}