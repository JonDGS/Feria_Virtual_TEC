using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace Feria_Virtual_REST.Models
{
    public static class UserManager
    {
        private static LinkedList<User> registerUsers = JsonManager.retrieveUsers();

        /*
         * Registers a user in the database
         * newUser: user being register
         * return: None
         */
        public static void registerUser(User newUser)
        {
            registerUsers.AddLast(newUser);
            JsonManager.saveUsers(registerUsers);
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

        public static LinkedList<User> getUsers()
        {
            return registerUsers;
        }

        /**
         * Description: Checks whether or not a username is available
         * Parameters:
         * - user: user
         * Return: bool whether or not it is available
         */
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

        /**
         * Description: Checks whether or not an email is available
         * Parameters:
         * - email: email
         * Return: bool whether or not it is available
         */
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


        /**
         * Description: Matches username to a type of user
         * Parameters:
         * - username: username
         * - type: type
         * Return: bool did it match type
         */
        public static bool doesUsernameMatchesType(string username, string type)
        {
            foreach(User user in registerUsers)
            {
                if (user.getUsername().Equals(username))
                {
                    if (user.getType().Equals(type))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /**
         * Description: Retrives a type by username
         * Parameters:
         * - user: user
         * Return: string of the type of user
         */
        public static string getTypeByUsername(string user)
        {
            if (!checkUserAvailability(user))
            {
                foreach(User currentUser in registerUsers)
                {
                    if (currentUser.getUsername().Equals(user))
                    {
                        return currentUser.getType();
                    }
                }
            }

            return null;
        }

        
        public static User getUser(string user)
        {
            foreach(User currentUser in registerUsers)
            {
                if (currentUser.getUsername().Equals(user))
                {
                    return currentUser;
                }
            }

            return null;
        }

        /**
         * Description: Modifies a given attribute in a given user
         * Parameters:
         * - username: username
         * - attribute: attribute
         * - value: value
         * Return: bool whether or not the change was made
         */
        public static bool modifyAttribute(string username, string attribute, string value)
        {
            User currentUser = getUser(username);

            if (!currentUser.Equals(null))
            {

                switch (currentUser.getType())
                {
                    case "Admin":

                        Admin currentAdmin = (Admin)currentUser;

                        switch (attribute)
                        {
                            case "username":
                                currentAdmin.username = value;
                                break;
                            case "email":
                                currentAdmin.email = value;
                                break;
                            case "passwordHash":
                                currentAdmin.username = HashComputer.GetHashString(value);
                                break;
                            default:
                                return false;
                        }

                        JsonManager.saveUsers(registerUsers);
                        return true;

                    case "Client":

                        Client currentClient = (Client)currentUser;

                        switch (attribute)
                        {
                            case "username":
                                currentClient.username = value;
                                break;
                            case "email":
                                currentClient.email = value;
                                break;
                            case "passwordHash":
                                currentClient.username = HashComputer.GetHashString(value);
                                break;
                            case "cedula":
                                currentClient.cedula = value;
                                break;
                            case "realName":
                                currentClient.realName = value;
                                break;
                            case "lastName1":
                                currentClient.lastName1 = value;
                                break;
                            case "provincia":
                                currentClient.address.provincia = value;
                                break;
                            case "canton":
                                currentClient.address.canton = value;
                                break;
                            case "distrito":
                                currentClient.address.distrito = value;
                                break;
                            case "month":
                                currentClient.dateOfBirth.month = Convert.ToInt32(value);
                                break;
                            case "day":
                                currentClient.dateOfBirth.day = Convert.ToInt32(value);
                                break;
                            case "year":
                                currentClient.dateOfBirth.year = Convert.ToInt32(value);
                                break;
                            case "phoneNumber":
                                currentClient.phoneNumber = value;
                                break;
                            default:
                                return false;
                        }

                        JsonManager.saveUsers(registerUsers);
                        return true;

                    case "Seller":

                        Seller currentSeller = (Seller)currentUser;

                        switch (attribute)
                        {
                            case "username":
                                currentSeller.username = value;
                                break;
                            case "email":
                                currentSeller.email = value;
                                break;
                            case "passwordHash":
                                currentSeller.username = HashComputer.GetHashString(value);
                                break;
                            case "cedula":
                                currentSeller.cedula = value;
                                break;
                            case "realName":
                                currentSeller.realName = value;
                                break;
                            case "lastName1":
                                currentSeller.lastName1 = value;
                                break;
                            case "provincia":
                                currentSeller.address.provincia = value;
                                break;
                            case "canton":
                                currentSeller.address.canton = value;
                                break;
                            case "distrito":
                                currentSeller.address.distrito = value;
                                break;
                            case "month":
                                currentSeller.dateOfBirth.month = Convert.ToInt32(value);
                                break;
                            case "day":
                                currentSeller.dateOfBirth.day = Convert.ToInt32(value);
                                break;
                            case "year":
                                currentSeller.dateOfBirth.year = Convert.ToInt32(value);
                                break;
                            case "phoneNumber":
                                currentSeller.phoneNumber = value;
                                break;
                            case "sinpe":
                                currentSeller.sinpe = value;
                                break;
                            case "lugarDeEntrega":
                                currentSeller.lugarDeEntrega = value;
                                break;
                            default:
                                return false;
                        }

                        JsonManager.saveUsers(registerUsers);
                        return true;

                    default:
                        return false;

                }

            }

            return false;

        }

        public static List<Seller> getSellers()
        {
            List<Seller> tempList = new List<Seller>();
            
            foreach(User user in registerUsers)
            {
                if(user.type == "Seller")
                {
                    tempList.Add((Seller)user);
                }
            }

            return tempList;
        }
    }
}