using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public static class JsonSerializer
    {

        private static string pathToProjectAdmin = "E:\OneDriveTEC\OneDrive - Estudiantes ITCR\GITHUB\Feria_Virtual_TEC\REST_api\Database\admins.json";
        private static string pathToProjectClient = "E:\OneDriveTEC\OneDrive - Estudiantes ITCR\GITHUB\Feria_Virtual_TEC\REST_api\Database\Client.json";
        private static string pathToProjectSeller = "E:\OneDriveTEC\OneDrive - Estudiantes ITCR\GITHUB\Feria_Virtual_TEC\REST_api\Database\Seller.json";

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

        }
    }
}