using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public static class TokenManager
    {
        
        public static LinkedList<TokenNode> tokens = new LinkedList<TokenNode>();

        
        public static string generateToken(string username)
        {
            doesUserHasToken(username);
            string newToken = Guid.NewGuid().ToString();
            tokens.AddLast(new TokenNode(newToken, username));
            return newToken;
        }

        public static bool doesUserHasToken(string username)
        {
            
            foreach(TokenNode tokenNode in tokens)
            {
                if (tokenNode.getUsername().Equals(username))
                {
                    tokens.Remove(tokenNode);
                    return true;
                }
            }

            return false;

        }

        public static bool validateToken(string token)
        {
            foreach (TokenNode tokenNode in tokens)
            {
                if (tokenNode.getToken().Equals(token))
                {
                    return true;
                }
            }

            return false;
        }

        public static string getUsernameFromToken(string token)
        {
            foreach (TokenNode tokenNode in tokens)
            {
                if (tokenNode.getToken().Equals(token))
                {
                    return tokenNode.getUsername();
                }
            }

            return null;
        }

    }
}