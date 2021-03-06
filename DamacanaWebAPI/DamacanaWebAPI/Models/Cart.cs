﻿using System;
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
        
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
        // TODO add more properties as necessary

        // items in the cart:

        //navigation property
        public virtual ICollection<Cart_Product> ProductsInTheCart { get; set; }

        //foreign key
        public Guid UserId { get; set; }
        // navigation property
        public virtual User User { get; set; }
    }
}