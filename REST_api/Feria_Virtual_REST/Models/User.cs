using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public abstract class User
    {
        public string username { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string type { get; set; }

        public User(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.passwordHash = HashComputer.GetHashString(password);
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getEmail()
        {
            return this.email;
        }
    }
}