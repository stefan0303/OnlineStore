﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineStore.Models;

namespace OnlineStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Products",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Products", action = "AllProducts", id = UrlParameter.Optional }
            );
          
            routes.MapRoute(
                name: "EditProducts",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Products", action = "EditProductDetail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditProductDetail",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Products", action = "EditProduct", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "NewProducts",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Products", action = "NewProducts", id = UrlParameter.Optional }
            //);
        }

       
    }
}
