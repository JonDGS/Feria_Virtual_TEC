using Feria_Virtual_REST.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Feria_Virtual_REST.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class RegisterController : ApiController
    {

        /**
         * Description: registry for a user
         * Parameters:
         * - user: username
         * - email: email
         * - password: password
         * Return: HttpStatusCode
         */
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


        /**
         * Description: registry for a Seller
         * Parameters:
         * - user: username
         * - email: email
         * - password: password
         * - cedula: cedula
         * - realName: user's real name
         * - lastName1: first lastname
         * - lastName2: second lastname
         * - provincia: province user lives in
         * - canton: canton user lives in
         * - distrito: distrito user lives in
         * - month: month number
         * - day: day number
         * - year: year number
         * - phoneNumber: phoneNumber
         * - sinpe: sinpe
         *- lugarDeEntrega: lugarDeEntrega
         * Return: HttpStatusCode
         */
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

        /**
         * Description: registry for a Seller
         * Parameters:
         * - user: username
         * - email: email
         * - password: password
         * - cedula: cedula
         * - realName: user's real name
         * - lastName1: first lastname
         * - lastName2: second lastname
         * - provincia: province user lives in
         * - canton: canton user lives in
         * - distrito: distrito user lives in
         * - month: month number
         * - day: day number
         * - year: year number
         * - phoneNumber: phoneNumber
         * Return: HttpStatusCode
         */
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
