using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class Client : User
    {
        public Client(string username, string email, string password) : base(username, email, password)
        {
            this.type = "Client";
        }
    }
}