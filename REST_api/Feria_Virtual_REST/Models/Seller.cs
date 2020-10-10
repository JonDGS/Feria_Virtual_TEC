using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class Seller : User
    {
        public Seller(string username, string email, string password) : base(username, email, password)
        {
            this.type = "Seller";
        }
    }
}