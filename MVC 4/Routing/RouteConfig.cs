using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCBasicsConcept
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //www.example.com/2011/04/05
            //www.example/products/cookies/oreo

            //always add your specific route first
            routes.MapRoute(
                name: "Default",
                url: "{year}/{month}/{day}",
                defaults: new
                {
                    controller = "Blog",
                    action = "Index",
                },

                constraints: new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }
             );

            //and after add your generic route
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new 
               { 
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional
               }
           );

        }
    }
}