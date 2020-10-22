using System;
using System.Collections.Generic;

namespace Feria_Virtual_REST.Models
{
    public class Order
    {
        public string addressToDeliver;
        public String ID;
        public string sellerAssigned;
        public List<Product> productsList = new List<Product>();
        public Date date;
        public Order(string addressToDeliver, string sellerAssigned, List<Product> productsList)
        {
            this.ID = TokenManager.generateRandomOrderID(12);
            this.addressToDeliver = addressToDeliver;
            this.sellerAssigned = sellerAssigned;
            this.productsList = productsList;

            DateTime currentTime = System.DateTime.Now;

            this.date = new Date(currentTime.Month, currentTime.Day, currentTime.Year);
        }

    }
}
