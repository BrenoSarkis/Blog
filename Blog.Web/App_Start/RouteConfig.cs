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
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //        name: "PostDetalhado",
            //        url: "{yyyy}/{mm}/{dd}/{titulo}",
            //        defaults: new { controller = "Post", action = "Obter" } 
            //        //constraints: new { yyyy = @"(19|20)\d\d.", mm = @"\d\d", dd = @"\d\d" }
            //    );

            routes.MapRoute(
                    "PostDetalhado",
                    "Blog/Detalhar/{ano}/{mes}/{dia}/{titulo}",
                    new { controller = "Blog", action="Detalhar" });
        }
    }
}
