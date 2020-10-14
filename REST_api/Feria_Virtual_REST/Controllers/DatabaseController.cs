using Feria_Virtual_REST.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

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
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }
            else if (UserManager.doesUsernameMatchesType(TokenManager.getUsernameFromToken(token), "Seller")) {

                return Request.CreateResponse(HttpStatusCode.OK, JsonManager.getProductJSON_String());
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

                Product newProduct = new Product(pName, category, price, packageMode, availability);

                ProductManager.registerProduct(newProduct);

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
        public HttpResponseMessage modifyUser(string user, string attribute, [FromUri]string value, [FromUri]string token)
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


    }
}
