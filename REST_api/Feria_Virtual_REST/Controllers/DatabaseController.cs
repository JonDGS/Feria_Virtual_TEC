using Feria_Virtual_REST.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Feria_Virtual_REST.Controllers
{
    public class DatabaseController : ApiController
    {
        // GET: api/Database
        public HttpResponseMessage Get([FromBody]string token)
        {
            if(UserManager.doesUsernameMatchesType(TokenManager.getUsernameFromToken(token), "Admin"))
            {
                LinkedList<User> tempList = JsonManager.retrieveUsers();

                List<User> resultList = new List<User>();
                
                foreach(User user in tempList)
                {
                    resultList.Add(user);
                }

                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(resultList));

            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        // GET: api/Database/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Database
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Database/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Database/5
        public void Delete(int id)
        {
        }
    }
}
