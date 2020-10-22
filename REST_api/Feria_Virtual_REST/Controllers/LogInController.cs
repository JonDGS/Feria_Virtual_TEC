using Feria_Virtual_REST.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Feria_Virtual_REST.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LogInController : ApiController
    {
        /**
         * Description: Log In a user
         * Parameters:
         * - user: username
         * - email: user's email
         * - password: password for the user
         * Return: returns a token for the user to use accross the rest api
         */
        // POST: api/LogIn/
        public HttpResponseMessage logInCredencials([FromUri] string user, [FromUri] string email, [FromUri] string password)
        {
            if (UserManager.validateCredentials(user, email, password))
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, TokenManager.generateToken(user));
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Username, email or password is not correct");

        }
    }
}
