using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class CartDTO
    {
        public Guid? Id { get; set; }

        //foreign key
        public Guid UserId { get; set; }        
    }
}