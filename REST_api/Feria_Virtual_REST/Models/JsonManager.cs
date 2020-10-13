using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

//Paths for computer and Laptop

/* Laptop
 * D:/OneDrive TEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/admins.json
 * D:/OneDrive TEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/clients.json
 * D:/OneDrive TEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/sellers.json
 */

/* Desktop
 * E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/admins.json
 * E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/clients.json
 * E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/sellers.json
 */

namespace Feria_Virtual_REST.Models
{
    public static class JsonManager
    {

        private static string pathToProjectAdmin = "E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/admins.json";
        private static string pathToProjectClient = "E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/clients.json";
        private static string pathToProjectSeller = "E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/sellers.json";

        public static void saveUsers(LinkedList<User> users)
        {
            List<Admin> listAdmins = new List<Admin>();
            List<Client> listClients = new List<Client>();
            List<Seller> listSellers = new List<Seller>();

            foreach (User user in users)
            {
                string userType = user.type;

                switch (userType)
                {
                    case "Admin":
                        listAdmins.Add((Admin)user);
                        break;
                    case "Client":
                        listClients.Add((Client)user);
                        break;
                    case "Seller":
                        listSellers.Add((Seller)user);
                        break;
                    default:
                        Console.WriteLine("Error in Client Type");
                        break;
                }

            }



            //Json convertion for admins to json file
            string resultJsonAdmins = JsonConvert.SerializeObject(listAdmins);
            File.WriteAllText(@pathToProjectAdmin, resultJsonAdmins);

            //Json convertion for clients to json file
            string resultJsonClients = JsonConvert.SerializeObject(listClients);
            File.WriteAllText(@pathToProjectClient, resultJsonClients);

            //Json convertion for Sellers to json file
            string resultJsonSellers = JsonConvert.SerializeObject(listSellers);
            File.WriteAllText(@pathToProjectSeller, resultJsonSellers);

        }

        public static LinkedList<User> retrieveUsers()
        {
            
            List<Admin> listAdmins = JsonConvert.DeserializeObject<List<Admin>>(File.ReadAllText(@pathToProjectAdmin));
            List<Client> listClients = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(@pathToProjectClient));
            List<Seller> listSellers = JsonConvert.DeserializeObject<List<Seller>>(File.ReadAllText(@pathToProjectSeller));

            LinkedList<User> tempUsers = new LinkedList<User>();

            if(listAdmins is List<Admin>)
            {
                foreach (User user in listAdmins)
                {
                    tempUsers.AddLast(user);
                }
            }

            if (listClients is List<Client>)
            {
                foreach (User user in listClients)
                {
                    tempUsers.AddLast(user);
                }
            }

            if (listSellers is List<Seller>)
            {
                foreach (User user in listSellers)
                {
                    tempUsers.AddLast(user);
                }
            }

            return tempUsers;

        }

        public static List<Seller> getSellers()
        {
            List<Seller> sellers = JsonConvert.DeserializeObject<List<Seller>>(File.ReadAllText(@pathToProjectSeller));

            if(sellers is List<Seller>)
            {
                return sellers;
            }

            return null;
        }

        public static string getSellersJSON_String()
        {
            string sellers = File.ReadAllText(@pathToProjectSeller);

            return sellers;
        }

        public static string getClientsJSON_String()
        {
            string clients = File.ReadAllText(@pathToProjectClient);

            return clients;
        }

        public static string getAdminJSON_String()
        {
            string admins = File.ReadAllText(@pathToProjectAdmin);

            return admins;
        }
    }
}