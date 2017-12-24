using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmpleoDotNet.WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Jobs", action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}