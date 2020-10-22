using Feria_Virtual_REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Feria_Virtual_REST.Controllers
{
    public class CategoryController : ApiController
    {
        [Route("api/Database/Create/Category")]
        /*
        * Description: Http request for adding a category
        * Parameters: All the atributes of Category class
        * Return: none
        */
        public HttpResponseMessage addCategory([FromUri] string categoryName, [FromUri] string token)
        {


            if (UserManager.doesUsernameMatchesType(TokenManager.getUsernameFromToken(token), "Admin"))
            {


                Category newCategory = new Category(TokenManager.generateRandomOrderID(4), categoryName);

                CategoryManager.registerCategory(newCategory);

                return new HttpResponseMessage(HttpStatusCode.Accepted);

            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }
        [Route("api/Database/GetCategories")]
        /*
         * Description: Show all the categories
         * Parameters: token
         * Return: all the categories
         */
        public HttpResponseMessage getCategories([FromUri] string token)
        {
            string username = TokenManager.getUsernameFromToken(token);

            if (UserManager.doesUsernameMatchesType(username, "Admin"))
            {

                return Request.CreateResponse(HttpStatusCode.OK, JsonManager.getCategoryJSON_String());
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}