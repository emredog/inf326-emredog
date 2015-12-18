using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaWebAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Address { get; set; }
        // TODO
    }
}