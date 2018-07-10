using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace OnlineStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            //http://localhost:49932/Cart/GetProduct/3029
            config.Routes.MapHttpRoute(
                name: "GetProduct",
                routeTemplate: "Cart/GetProduct/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            RouteTable.Routes.MapHttpRoute(
                name: "GetGartCount",
                routeTemplate: "api/Get/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
            //We remove the default XML formater, now we will received JSON format
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
