using System.Web.Mvc;
using System.Web.Routing;

namespace EmpleoDotNet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name:"rss",
                url:"rss",
                defaults: new {controller = "Home", action = "rss"}
                );

            routes.MapRoute(
                name: "job",
                url: "jobs/{id}",
                defaults: new { controller = "JobOpportunity", action = "Detail" },
                constraints: new {id = @"\d+[a-z-A-Z-]+" }
            );

            routes.MapRoute(
                name: "Default job route",
                url: "jobs/{action}",
                defaults: new { controller = "JobOpportunity", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
