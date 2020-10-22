using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Feria_Virtual_REST.Models
{
    public static class JsonManager
    {

        private static string pathToProjectAdmin = AppDomain.CurrentDomain.BaseDirectory + "/Database/admins.json";
        private static string pathToProjectClient = AppDomain.CurrentDomain.BaseDirectory + "/Database/clients.json";
        private static string pathToProjectSeller = AppDomain.CurrentDomain.BaseDirectory + "/Database/sellers.json";
        private static string pathToProjectProduct = AppDomain.CurrentDomain.BaseDirectory + "/Database/products.json";
        private static string pathToProjectOrder = AppDomain.CurrentDomain.BaseDirectory + "/Database/orders.json";
        private static string pathToProjectCategory = AppDomain.CurrentDomain.BaseDirectory + "/Database/categories.json";
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
        public static void saveProduct(LinkedList<Product> products)
        {
            List<Product> listProducts = new List<Product>();

            foreach (Product product in products)
            {
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

            if (listAdmins is List<Admin>)
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
            if (listProducts is List<Product>)
            {
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

        /*
        * Description: Retrieve the products form DB
        * Parameters: None
        * Return: All the products loaded in DB
        */
        public static LinkedList<Category> retrieveCategories()
        {

            List<Category> listCategories = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(pathToProjectCategory));
            if (listCategories is List<Category>)
            {
                LinkedList<Category> tempCategories = new LinkedList<Category>();

                foreach (Category category in listCategories)
                {
                    tempCategories.AddLast(category);

                }

                return tempCategories;
            }
            return new LinkedList<Category>();
        }

        public static void saveCategory(LinkedList<Category> categories)
        {
            List<Category> listCategory = new List<Category>();

            foreach (Category category in categories)
            {
                listCategory.Add(category);
            }
            string resultJsonCategory = JsonConvert.SerializeObject(listCategory);
            File.WriteAllText(pathToProjectCategory, resultJsonCategory);
        }

        public static List<Seller> getSellers()
        {
            List<Seller> sellers = JsonConvert.DeserializeObject<List<Seller>>(File.ReadAllText(@pathToProjectSeller));

            if (sellers is List<Seller>)
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

        public static string getCategoryJSON_String()
        {
            string categories = File.ReadAllText(@pathToProjectCategory);

            return categories;
        }
    }
}