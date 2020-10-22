using System.Web.Http;

namespace Feria_Virtual_REST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //CORS 
            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
