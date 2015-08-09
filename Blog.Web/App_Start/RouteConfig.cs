using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                    "PostDetalhado",
                    "{ano}/{mes}/{dia}/{titulo}",
                    new { controller = "Blog", action = "Detalhar" });

            routes.MapRoute(
                "Sobre",
                "Sobre",
                new { controller = "Home", action = "Sobre" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional });
        }
    }
}
