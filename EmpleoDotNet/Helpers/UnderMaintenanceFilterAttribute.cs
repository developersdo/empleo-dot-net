using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using EmpleoDotNet.AppServices;
using Ninject;

namespace EmpleoDotNet.Helpers
{
    public class UnderMaintenanceFilterAttribute : ActionFilterAttribute
    {
        [Inject]
        public ISettingsProvider Settings { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Contains("Error") ||
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Contains("Credits") ||
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Contains("UnderMaintenance")
                )
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            bool underMaintenance;

            bool.TryParse(Settings.Get("UnderMaintenance"), out underMaintenance);

            if (underMaintenance)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "UnderMaintenance"},
                        { "action", "Index"}
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
