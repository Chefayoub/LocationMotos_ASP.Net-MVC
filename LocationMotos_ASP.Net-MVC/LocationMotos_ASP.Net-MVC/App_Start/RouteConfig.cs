using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LocationMotos_ASP.Net_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Test /Ajouter/4/5
            routes.MapRoute(
               name: "Ajouter",
               url: "Ajouter/{valeur1}/{valeur2}",
               defaults: new { controller = "Home", action = "Ajouter", valeur1 = 0, valeur2 = 0 }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
