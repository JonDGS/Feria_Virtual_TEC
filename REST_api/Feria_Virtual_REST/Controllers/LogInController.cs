﻿using Feria_Virtual_REST.Models;
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
        // POST: api/LogIn/
       public HttpResponseMessage logInCredencials([FromUri] string user, [FromUri] string email, [FromUri] string password, [FromUri] string type)
        {
            if(UserManager.validateCredentials(user, email, password))
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, TokenManager.generateToken(user));
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Username, email or password is not correct");

        }
    }
}