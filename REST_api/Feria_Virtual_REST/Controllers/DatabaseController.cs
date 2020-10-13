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
        public HttpResponseMessage getAllUsers(string who)
        {

            string token = HttpContext.Current.Request.Params["token"];

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
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }



    }
}
