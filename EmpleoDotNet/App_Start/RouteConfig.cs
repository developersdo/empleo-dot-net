using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmpleoDotNet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           //habilita el atributo de rutas en el controlador
             routes.MapMvcAttributeRoutes();

           /* routes.MapRoute(
              name: "JobOpportunity-Pretty",
              url: "{controller}/{id}/{description}",
              defaults: new
              {
                  controller = "JobOpportunity",
                  action = "Detail",
                  id = UrlParameter.Optional,
                  description = UrlParameter.Optional
              }
          );*/

             routes.MapRoute(
                             "JobOpportunity-Pretty",
                             "JobOpportunity/{id}/{description}",
                             new { controller = "JobOpportunity", action = "Detail" }
                            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }

        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
