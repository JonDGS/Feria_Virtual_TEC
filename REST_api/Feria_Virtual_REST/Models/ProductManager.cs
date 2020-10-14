using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public static class ProductManager
    {
        private static LinkedList<Product> registeredProducts = JsonManager.retrieveProducts();

        /*
         * Description: Registers a product in the database
         * Parameters: newProduct-> product being registered
         * Return: None
         */
        public static void registerProduct(Product newProduct)
        {
            registeredProducts.AddLast(newProduct);
            JsonManager.saveProduct(registeredProducts);
        }
    }
}