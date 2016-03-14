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
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();
        }
    }
}