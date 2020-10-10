using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public static class TokenManager
    {
        
        public static string generateToken()
        {
            return Guid.NewGuid().ToString();
        }

    }
}