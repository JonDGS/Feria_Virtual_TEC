using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.ModelBinding;

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

        public static List<Product> getProductsBasedOnSeller(string user)
        {
            List<Product> sellerProducts = new List<Product>();

            foreach(Product product in registeredProducts)
            {
                if (product.seller.Equals(user))
                {
                    sellerProducts.Add(product);
                }
            }

            if(sellerProducts.Count == 0)
            {
                return null;
            }

            return sellerProducts;
        }

        public static List<Product> sortListBy(List<Product> products, string attribute)
        {
            if(products.Count == 1)
            {
                return products;
            }

            List<Product> sortedProducts = new List<Product>();
            sortedProducts.Add(products[0]);
            
            for(int outerIndex = 1; outerIndex < products.Count; outerIndex++)
            {
                Product currentProduct = products[outerIndex];

                for (int innerIndex = 0; innerIndex <= sortedProducts.Count(); innerIndex++)
                {

                    switch (attribute)
                    {
                        case "sold":
                            if (sortedProducts.Count() == innerIndex)
                            {
                                sortedProducts.Add(currentProduct);
                                break;
                            }

                            if (currentProduct.sold > sortedProducts[innerIndex].sold)
                            {
                                sortedProducts.Insert(innerIndex, currentProduct);
                                break;
                            }
                            break;
                        case "revenue":
                            if (sortedProducts.Count() == innerIndex)
                            {
                                sortedProducts.Add(currentProduct);
                                break;
                            }

                            if (currentProduct.revenue > sortedProducts[innerIndex].revenue)
                            {
                                sortedProducts.Insert(innerIndex, currentProduct);
                                break;
                            }
                            break;
                        default:
                            return null;
                    }

                }
            }

            return sortedProducts;

            
        }
        
        public static List<Product> getTopN_ProductsPerSellerByAttribute(string user, string attribute, int numberOfTop)
        {
            List<Product> sellerProducts = getProductsBasedOnSeller(user);

            return sortListBy(sellerProducts, attribute).GetRange(0, numberOfTop);
        }
    }
}