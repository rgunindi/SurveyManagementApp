using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SurveyManagementApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "SurveyApp",
               url: "{Manager}/{action}/{id}",
               defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
           );

        //    routes.MapRoute(
        //      "Admin_default",
        //      "Admin/{controller}/{action}/{id}",
        //      new { action = "Index", id = UrlParameter.Optional }
        //  );
        //    routes.MapRoute(
        //        "Login_default",
        //        "Login/{controller}/{action}/{id}",
        //        new { action = "Index", id = UrlParameter.Optional }
        //    );
        //
        }
    }
}
