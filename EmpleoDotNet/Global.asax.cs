using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EmpleoDotNet.Code;

namespace EmpleoDotNet
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.InstrumentationKey =
               ConfigurationManager.AppSettings["AppInsightsKey"];
            }
            catch(Exception)
            {
                // Oh Sh!t - No Telemetry Son!
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();
        }
    }
}