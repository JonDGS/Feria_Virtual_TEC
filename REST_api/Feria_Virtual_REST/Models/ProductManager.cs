using System.Collections.Generic;
using System.Linq;

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

        /*
         * Description: Deletes a product in the database
         * Parameter: usernameToDelete
         * return: bool
         */
        public static bool deleteProduct(string productToDelete, string username)
        {
            foreach (Product product in registeredProducts)
            {
                if (product.seller.Equals(username))
                {
                    if (product.pName.Equals(productToDelete))
                    {
                        registeredProducts.Remove(product);
                        JsonManager.saveProduct(registeredProducts);
                        return true;
                    }
                }
            }
            return false;
        }
        /*
         * Description: Deletes all product from a seller in the database
         * Parameter: username
         * return: bool
         */
        public static bool deleteProduct(string username)
        {
            var index = registeredProducts.First;
            while (index != null)
            {
                var nextIndex = index.Next;
                if (index.Value.seller.Equals(username))
                {
                    registeredProducts.Remove(index);


                }
                index = nextIndex;
            }
            JsonManager.saveProduct(registeredProducts);
            return true;
        }

        public static List<Product> getProductsBasedOnSeller(string user)
        {
            List<Product> sellerProducts = new List<Product>();

            foreach (Product product in registeredProducts)
            {
                if (product.seller.Equals(user))
                {
                    sellerProducts.Add(product);
                }
            }

            if (sellerProducts.Count == 0)
            {
                return null;
            }

            return sellerProducts;
        }

        public static List<Product> sortProductListBy(List<Product> products, string attribute)
        {
            if (products.Count == 1)
            {
                return products;
            }

            List<Product> sortedProducts = new List<Product>();
            sortedProducts.Add(products[0]);

            for (int outerIndex = 1; outerIndex < products.Count; outerIndex++)
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

            return sortProductListBy(sellerProducts, attribute).GetRange(0, numberOfTop);
        }

        public static List<Product> getProductsAsA_List()
        {
            List<Product> products = new List<Product>();

            foreach (Product product in registeredProducts)
            {
                products.Add(product);
            }

            return products;

        }

        public static int countSellerSells(string user)
        {
            int counter = 0;

            foreach (Product product in registeredProducts)
            {
                if (product.seller.Equals(user))
                {
                    counter++;
                }
            }

            return counter;

        }

        public static List<SellerSortingInfo> sortSellerListBy(List<Seller> sellers, string attribute)
        {
            if (sellers.Count() == 1)
            {
                List<SellerSortingInfo> tempList = new List<SellerSortingInfo>();
                tempList.Add(new SellerSortingInfo(sellers[0].username, countSellerSells(sellers[0].username)));
                return tempList;
            }

            List<SellerSortingInfo> sortedSellers = new List<SellerSortingInfo>();

            sortedSellers.Add(new SellerSortingInfo(sellers[0].username, countSellerSells(sellers[0].username)));


            foreach (Seller seller in sellers)
            {
                int productsSold = countSellerSells(seller.username);

                bool isNotLast = true;

                for (int index = 1; index < sortedSellers.Count(); index++)
                {
                    if (productsSold >= sortedSellers[0].numberOfSales)
                    {
                        sortedSellers.Insert(index, new SellerSortingInfo(seller.username, productsSold));
                        isNotLast = false;
                        break;
                    }
                }

                if (!isNotLast)
                {
                    sortedSellers.Add(new SellerSortingInfo(seller.username, productsSold));
                }

            }

            return sortedSellers;
        }

        public static List<SellerSortingInfo> getTopN_SellerByAttribute(string attribute, int numberOfTop)
        {
            List<Seller> sellers = UserManager.getSellers();

            return sortSellerListBy(sellers, attribute).GetRange(0, numberOfTop);
        }

        public static List<Product> getTopN_Products(string attribute, int number)
        {
            List<Product> sortedProducts = new List<Product>();

            bool firstDone = false;

            foreach (Product product in registeredProducts)
            {
                if (firstDone)
                {
                    switch (attribute)
                    {

                        case "Sold":

                            for (int index = 0; index < sortedProducts.Count(); index++)
                            {
                                if (product.sold >= sortedProducts[index].sold)
                                {
                                    sortedProducts.Insert(index, product);
                                    break;
                                }

                                sortedProducts.Add(product);
                            }

                            break;
                        case "Revenue":
                            for (int index = 0; index < sortedProducts.Count(); index++)
                            {
                                if ((product.sold * product.price) >= (sortedProducts[index].sold * sortedProducts[index].price))
                                {
                                    sortedProducts.Insert(index, product);
                                    break;
                                }

                                sortedProducts.Add(product);
                            }

                            break;
                        default:
                            return null;
                    }
                }
                else
                {
                    sortedProducts.Add(product);
                    firstDone = true;
                }
            }

            return sortedProducts.GetRange(0, number);
        }

    }
}