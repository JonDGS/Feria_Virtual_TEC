using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class TokenNode
    {

        private string token;
        private string username;

        public TokenNode(string token, string username)
        {
            this.token = token;
            this.username = username;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getToken()
        {
            return this.token;
        }

    }
}