using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace Feria_Virtual_REST.Models
{
    public static class UserManager
    {
        private static LinkedList<User> registerUsers = new LinkedList<User>();

        /*
         * Registers a user in the database
         * newUser: user being register
         * return: None
         */
        public static void registerUser(User newUser)
        {
            registerUsers.AddLast(newUser);
            JsonSerializer.saveUsers(registerUsers);
        }

        /*
         * Validates the credentials for a user
         * username: username for the user
         * email: email for the user
         * password: password for the user
         * return: boolean whether or not the credentials are correct
         */
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

        public static bool checkUserAvailability(string user)
        {
            foreach(User currentUser in registerUsers)
            {
                if (currentUser.getUsername().Equals(user))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool checkEmailAvailability(string email)
        {
            foreach (User currentUser in registerUsers)
            {
                if (currentUser.getEmail().Equals(email))
                {
                    return false;
                }
            }

            return true;
        }
    }
}