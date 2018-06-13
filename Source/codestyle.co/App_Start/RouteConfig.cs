using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace codestyle.co
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new
            {
                favicon = @"(.*/)?favicon.ico(/.*)?"
            });

            routes.MapRoute(
                name: "NotFound",
                url: "NotFound",
                defaults: new
                {
                    controller = "Error",
                    action = "NotFound",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Guidelines",
                url: "Guidelines/{id}",
                defaults: new
                {
                    controller = "Guidelines",
                    action = "Index"
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index"
                }
            );
        }
    }
}
