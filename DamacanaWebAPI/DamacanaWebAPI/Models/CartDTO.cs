﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    // This class is used when listing all the cards (GET - List endpoint)
    public class CartDTO
    {
        public Guid Id { get; set; }
        // TODO add more properties as necessary
        public String UserName { get; set; }

        public Decimal TotalAmount { get; set; }
    }
}