using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Xpedia
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "BlogURL",
               url: "blogdetail/{slug}",
               defaults: new { controller = "Blog", action = "BlogDetail", slug = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Car",
               url: "car",
               defaults: new { controller = "Car", action = "Car", id = UrlParameter.Optional },
               namespaces: new[] { "Xpedia.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Xpedia.Controllers" }
            );
        }
    }
}
