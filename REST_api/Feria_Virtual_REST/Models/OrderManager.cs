using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class OrderManager
    {
        public static LinkedList<Order> registeredOrders = JsonManager.retrieveOrder();

        /*
         * Description: Registers an order in the database
         * Parameters: newProduct-> product being registered
         * Return: None
         */
        public static void registerOrder(Order newOrder)
        {
            registeredOrders.AddLast(newOrder);
            JsonManager.saveOrder(registeredOrders);
        }
    }
}
