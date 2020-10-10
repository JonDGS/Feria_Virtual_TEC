using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public static class UserManager
    {
        private static LinkedList<User> registerUsers = new LinkedList<User>();

        public static void registerUser(User newUser)
        {
            registerUsers.AddLast(newUser);
            //Save the data in json file
        }

        public static bool validateCredentials(string username, string email, string password)
        {
            foreach (User current in registerUsers)
            {
                if (current.username.Equals(username))
                {
                    if (current.email.Equals(email))
                    {
                        if (current.passwordHash.Equals(HashComputer.GetHashString(password)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static void retrieveUsers()
        {
            //retrieve users from JSON
        }

        public static LinkedList<User> getUsers()
        {
            return registerUsers;
        }
    }
}