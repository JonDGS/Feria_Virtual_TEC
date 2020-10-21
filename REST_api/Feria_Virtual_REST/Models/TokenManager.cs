using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public static class TokenManager
    {
        
        public static LinkedList<TokenNode> tokens = new LinkedList<TokenNode>();

        
        /**
         * Description: Generates a token for a given user
         * Parameters:
         * - username: username
         * Return: token
         */
        public static string generateToken(string username)
        {
            doesUserHasToken(username);
            string newToken = Guid.NewGuid().ToString();
            tokens.AddLast(new TokenNode(newToken, username));
            return newToken;
        }

        /**
         * Checks whether or not the user already being assigned a token
         * Parameters:
         * - username: usermane
         * Return: bool whether or not there is a valid token
         */
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

        /**
         * Description: validates if the token is valid
         * Parameters:
         * - token: token
         * Return: token
         */
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

        /**
         * Description: gets a username based on a token
         * Parameters:
         * - token: token
         * Return: Username associated with token
         */
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