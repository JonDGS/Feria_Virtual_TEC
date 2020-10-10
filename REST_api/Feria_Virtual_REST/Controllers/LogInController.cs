using Feria_Virtual_REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Feria_Virtual_REST.Controllers
{
    public class LogInController : ApiController
    {
        // GET: api/LogIn
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LogIn/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LogIn/
        public HttpResponseMessage Post([FromUri]string user, [FromUri]string email, [FromUri]string password, [FromUri]string type)
        {
            if(UserManager.checkUserAvailability(user) && UserManager.checkEmailAvailability(email))
            {
                User newUser = null;

                switch (type)
                {
                    case "Admin":
                        newUser = new Admin(user, email, password);
                        break;
                    case "Client":
                        newUser = new Client(user, email, password);
                        break;
                    case "Seller":
                        newUser = new Seller(user, email, password);
                        break;
                    default:
                        return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                UserManager.registerUser(newUser);

                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username or email already in use");

        }

        // PUT: api/LogIn/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LogIn/5
        public void Delete(int id)
        {
        }
    }
}
