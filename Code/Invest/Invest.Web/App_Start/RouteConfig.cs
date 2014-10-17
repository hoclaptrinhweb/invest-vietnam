using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Invest.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            //Register Route Plugin 
            routes.MapRoute(
                "NetAdvImage",
                "Content/editors/tinymce/plugins/netadvimage/{action}",
                new { controller = "NetAdvImage" }
            );

            routes.MapRoute(
                "Category",
                "{culture}/Category/{Name}.{Id}",
                new
                {
                    culture = "en",
                    controller = "Category",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                   new[] { "Invest.Web.Controllers" }
          );

            routes.MapRoute(
               "News",
               "{culture}/news/{Name}.{Id}",
               new
               {
                   culture = "en",
                   controller = "News",
                   action = "Index",
                   id = UrlParameter.Optional
               },
                  new[] { "Invest.Web.Controllers" }
         );
            #region Ajax
            routes.MapRoute(
               "Calling-Ajax",
               "ajax/{controller}/{action}/{*q}",
                   new[] { "Invest.Web.Controllers" }
            );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { culture = "en", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Invest.Web.Controllers" }
           );

        }
    }
}
