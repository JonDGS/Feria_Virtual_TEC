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
 * D:/OneDrive TEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/products.json
 * D:/OneDrive TEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/orders.json
 */

/* Desktop
 * E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/admins.json
 * E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/clients.json
 * E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/sellers.json
 * E:/OneDriveTEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/products.json
 * E:/OneDrive TEC/OneDrive - Estudiantes ITCR/GITHUB/Feria_Virtual_TEC/REST_api/Database/orders.json
 */

/*
 * C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/admins.json    
 * C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/clients.json   
 * C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/sellers.json
 * C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/products.json
 * C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/orders.json
*/

namespace Feria_Virtual_REST.Models
{
    public static class JsonManager
    {

        private static string pathToProjectAdmin = "C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/admins.json";
        private static string pathToProjectClient = "C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/clients.json";
        private static string pathToProjectSeller = "C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/sellers.json";
        private static string pathToProjectProduct = "C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/products.json";
        private static string pathToProjectOrder = "C:/Users/SMZ19/OneDrive/Documentos/GitHub/Feria_Virtual_TEC/REST_api/Database/orders.json";
        /**
         * Description: Save current users to a json file in database
         * Parameters:
         * users: Users store in memory
         * Return: void
         */
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
        /*
        * Description: Serialize the product data and save it to DB
        * Parameters: Linked list that contains all the products
        * Return: none
        */
        public static void saveProduct(LinkedList<Product> products) {
            List<Product> listProducts = new List<Product>();

            foreach (Product product in products) {
                listProducts.Add(product);
            }
            string resultJsonProducts = JsonConvert.SerializeObject(listProducts);
            File.WriteAllText(pathToProjectProduct, resultJsonProducts);
        }
        /*
       * Description: Serialize the order data and save it to DB
       * Parameters: Linked list that contains all the or
       * Return: none
       */
        public static void saveOrder(LinkedList<Order> orders)
        {
            List<Order> listOrders = new List<Order>();

            foreach (Order order in orders)
            {
                listOrders.Add(order);
            }
            string resultJsonOrders = JsonConvert.SerializeObject(listOrders);
            File.WriteAllText(pathToProjectOrder, resultJsonOrders);
        }

        /*
        * Description: Retrieve the users form DB
        * Parameters: None
        * Return: All the users loaded in DB
        */
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
        /*
        * Description: Retrieve the products form DB
        * Parameters: None
        * Return: All the products loaded in DB
        */
        public static LinkedList<Product> retrieveProducts()
        {

            List<Product> listProducts = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(@pathToProjectProduct));
            if (listProducts is List<Product>) {
                LinkedList<Product> tempProducts = new LinkedList<Product>();

                foreach (Product product in listProducts)
                {
                    tempProducts.AddLast(product);

                }

                return tempProducts;
            }
            return new LinkedList<Product>();
        }
        /*
        * Description: Retrieve the orders form DB
        * Parameters: None
        * Return: All the orders loaded in DB
        */
        public static LinkedList<Order> retrieveOrder()
        {

            List<Order> listOrders = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(@pathToProjectOrder));
            if (listOrders is List<Order>)
            {
                LinkedList<Order> tempOrders = new LinkedList<Order>();

                foreach (Order order in listOrders)
                {
                    tempOrders.AddLast(order);

                }

                return tempOrders;
            }
            return new LinkedList<Order>();
        }
        /*
        * Description: Convert string to list 
        * Parameters: string in JSON format
        * Return: List of products
        */
        public static List<Product> convertStringToList(string productsListInJsonFormat)
        {

            List<Product> listProduct = JsonConvert.DeserializeObject<List<Product>>(productsListInJsonFormat);
            
            return listProduct;
        }
        /*
        * Description: Convert order list to string
        * Parameters: string in JSON format
        * Return: List of orders assigned to a seller
        */
        public static string convertListToJson(List<Order> assignedOrderList)
        {
            
            string listOrderInJson = JsonConvert.SerializeObject(assignedOrderList);

            return listOrderInJson;
        }
        /*
        * Description: Convert product list to string
        * Parameters: string in JSON format
        * Return: List of orders assigned to a seller
        */
        public static string convertListToJson(List<Product> assignedProductList)
        {

            string listOrderInJson = JsonConvert.SerializeObject(assignedProductList);

            return listOrderInJson;
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

        public static string getProductJSON_String()
        {
            string admins = File.ReadAllText(@pathToProjectProduct);

            return admins;
        }
        public static string getOrderJSON_String()
        {
            string orders = File.ReadAllText(@pathToProjectOrder);

            return orders;
        }
    }
}