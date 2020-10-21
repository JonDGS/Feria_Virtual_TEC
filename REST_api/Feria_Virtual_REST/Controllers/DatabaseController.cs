using Feria_Virtual_REST.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Feria_Virtual_REST.Controllers
{
    public class DatabaseController : ApiController
    {
        [Route("api/Database/{who}")]
        /*
         * Description: Show all the different data in DB
         * Parameters: who -> person or thing that we want the information about
         * Return: Data of requested person or thing
         */
        public HttpResponseMessage getInfoDB(string who, [FromUri] string token)
        {



            if (UserManager.doesUsernameMatchesType(TokenManager.getUsernameFromToken(token), "Admin"))
            {
                switch (who)
                {
                    case "All":
                        LinkedList<User> tempList = JsonManager.retrieveUsers();

                        List<User> allUsersList = new List<User>();

                        foreach (User user in tempList)
                        {
                            allUsersList.Add(user);
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(allUsersList));
                    case "Sellers":
                        return Request.CreateResponse(HttpStatusCode.OK, JsonManager.getSellersJSON_String());
                    case "Clients":
                        return Request.CreateResponse(HttpStatusCode.OK, JsonManager.getClientsJSON_String());
                    case "Admins":
                        return Request.CreateResponse(HttpStatusCode.OK, JsonManager.getAdminJSON_String());
                    case "Products":
                        return Request.CreateResponse(HttpStatusCode.OK, JsonManager.getProductJSON_String());
                    case "Orders":
                        return Request.CreateResponse(HttpStatusCode.OK, JsonManager.getOrderJSON_String());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        [Route("api/Database/GetProducts")]
        /*
         * Description: Show all the order assigned to a seller
         * Parameters: who -> seller
         * Return: Seller's orders
         */
        public HttpResponseMessage getProductsFromSellers([FromUri] string token)
        {
            string username = TokenManager.getUsernameFromToken(token);

            if (UserManager.doesUsernameMatchesType(username, "Seller"))
            {

                List<Product> productsAssignedToSeller = ProductManager.getProductsBasedOnSeller(username);

                return Request.CreateResponse(HttpStatusCode.OK, JsonManager.convertListToJson(productsAssignedToSeller));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

            [Route("api/Database/GetOrdersFrom/{who}")]
        /*
         * Description: Show all the order assigned to a seller
         * Parameters: who -> seller
         * Return: Seller's orders
         */
        public HttpResponseMessage getOrdersFromProducer(string who, [FromUri] string token)
        {

            if (UserManager.doesUsernameMatchesType(TokenManager.getUsernameFromToken(token), "Seller"))
            {
                LinkedList<Order> currentOrderList = OrderManager.registeredOrders;
                List<Order> orderAssignedToSeller = new List<Order>();
                foreach (Order order in currentOrderList) {
                    if (order.sellerAssigned.Equals(who)) {
                        orderAssignedToSeller.Add(order);

                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, JsonManager.convertListToJson(orderAssignedToSeller));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [Route("api/Database/Create/Product")]
        /*
        * Description: Http request for adding a product
        * Parameters: All the atributes of Product class
        * Return: none
        */
        public HttpResponseMessage addProduct([FromUri] string pName, [FromUri] string category, [FromUri] int price, [FromUri] string packageMode, [FromUri] int availability, [FromUri] string token)
        {


            if (UserManager.doesUsernameMatchesType(TokenManager.getUsernameFromToken(token), "Seller"))
            {

                string sellerUsername = TokenManager.getUsernameFromToken(token);

                Product newProduct = new Product(pName, category, price, packageMode, availability, sellerUsername);

                ProductManager.registerProduct(newProduct);

                return new HttpResponseMessage(HttpStatusCode.Accepted);

            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }
        [Route("api/Database/Create/Order")]
        /*
        * Description: Http request for adding an order
        * Parameters: All the atributes of Order class
        * Return: none
        */
        public HttpResponseMessage addOrder([FromUri] int ID, [FromUri] string addressToDeliver, [FromUri] string sellerAssigned, [FromUri] string productsListInJsonFormat, [FromUri] string token)
        {
            if (UserManager.doesUsernameMatchesType(TokenManager.getUsernameFromToken(token), "Client"))
            {

                Order newOrder = new Order(addressToDeliver, sellerAssigned, JsonManager.convertStringToList(productsListInJsonFormat));

                OrderManager.registerOrder(newOrder);

                return new HttpResponseMessage(HttpStatusCode.Accepted);

            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        /**
         * Description: Access for modifying an attribute of a user
         * Parameters:
         * - user: user being modified
         * - attribute: attribute being modified
         * - value: value being given to the user
         * - token: requestee identity
         * Return: HttpStatusCode
         */
        [Route("api/Database/Modify/{user}/{attribute}")]
        public HttpResponseMessage modifyUser(string user, string attribute, [FromUri] string value, [FromUri] string token)
        {
            if (UserManager.doesUsernameMatchesType(TokenManager.getUsernameFromToken(token), "Admin"))
            {
                if (UserManager.modifyAttribute(user, attribute, value))
                {
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User or attribute not found");

            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [Route("api/Database/Report/{it}/{attribute}")]
        public HttpResponseMessage getReport(string it, string attribute)
        {
            return null;
        }


    }
}
