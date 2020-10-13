using Feria_Virtual_REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Feria_Virtual_REST.Controllers
{
    public class RegisterController : ApiController
    {

        [Route("api/Register/Admin")]
        public HttpResponseMessage registerAdmn([FromUri] string user, [FromUri] string email, [FromUri] string password)
        {
            if (UserManager.checkUserAvailability(user) && UserManager.checkEmailAvailability(email))
            {

                User newUser = new Admin(user, email, HashComputer.GetHashString(password));

                UserManager.registerUser(newUser);

                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username or email already in use");

        }


        [Route("api/Register/Seller")]
        public HttpResponseMessage registerAdmin([FromUri] string user, [FromUri] string email, [FromUri] string password,
            [FromUri] string cedula, [FromUri] string realName, [FromUri] string lastName1, [FromUri] string lastName2, [FromUri] string provincia,
            [FromUri] string canton, [FromUri] string distrito, [FromUri] int month, [FromUri] int day, [FromUri] int year,
            [FromUri] string phoneNumber, [FromUri] string sinpe, [FromUri] string lugarDeEntrega)
        {
            if (UserManager.checkUserAvailability(user) && UserManager.checkEmailAvailability(email))
            {
                User newUser = new Seller(user, email, HashComputer.GetHashString(password), cedula, realName, lastName1, lastName2,
                    provincia, canton, distrito, month, day, year, phoneNumber, sinpe, lugarDeEntrega);

                UserManager.registerUser(newUser);

                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username or email already in use");
        }

        [Route("api/Register/Client")]
        public HttpResponseMessage registerClient([FromUri] string user, [FromUri] string email, [FromUri] string password,
           [FromUri] string cedula, [FromUri] string realName, [FromUri] string lastName1, [FromUri] string lastName2, [FromUri] string provincia,
           [FromUri] string canton, [FromUri] string distrito, [FromUri] int month, [FromUri] int day, [FromUri] int year, [FromUri] string phoneNumber)
        {
            if (UserManager.checkUserAvailability(user) && UserManager.checkEmailAvailability(email))
            {
                User newUser = new Client(user, email, HashComputer.GetHashString(password), cedula, realName, lastName1, lastName2,
                    provincia, canton, distrito, month, day, year, phoneNumber);

                UserManager.registerUser(newUser);

                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username or email already in use");
        }
    }
}
