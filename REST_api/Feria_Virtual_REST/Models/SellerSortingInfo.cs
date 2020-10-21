using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class SellerSortingInfo
    {

        public string username;
        public int numberOfSales;

        public SellerSortingInfo(string username, int numberOfSales)
        {
            this.username = username;
            this.numberOfSales = numberOfSales;
        }

    }
}