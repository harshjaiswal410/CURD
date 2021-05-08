using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrudOperation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Company", action = "GetDetails", id = UrlParameter.Optional   }
            );
            routes.MapRoute(
               name: "EditEmployee",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Company", action = "EditEmployee", id = UrlParameter.Optional,fname=UrlParameter.Optional,lname=UrlParameter.Optional}
           );
            /*routes.MapRoute(
                name: "DeleteData",
                url: "{controller}/{action}",
                defaults: new { controller = "Company", action = "DeleteEmployee", id = UrlParameter.Optional }
            );*/
            routes.MapMvcAttributeRoutes();
        }
    }
}
