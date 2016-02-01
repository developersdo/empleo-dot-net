using System.Web.Mvc;
using System.Web.Routing;

namespace EmpleoDotNet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "JobName",
                "jobopportunity/detail/{id}/{seoName}",
                new { controller = "JobOpportunity", action = "Detail", seoName = "" },
                new { id = @"^\d+$" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
