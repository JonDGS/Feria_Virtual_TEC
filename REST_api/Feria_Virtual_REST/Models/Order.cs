using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class Order
    {
        public string addressToDeliver;
        public int ID;
        public string sellerAssigned;
        public List<Product> productsList = new List<Product>();
        public Order(int ID, string addressToDeliver, string sellerAssigned, List<Product> productsList)
        {
            this.ID = ID;
            this.addressToDeliver = addressToDeliver;
            this.sellerAssigned = sellerAssigned;
            this.productsList = productsList;

        }

    }
}
