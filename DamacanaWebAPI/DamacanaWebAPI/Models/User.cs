using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class User
    { 
        public Guid Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        public String Address { get; set; }
        // TODO
    }
}