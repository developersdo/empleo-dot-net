using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmpleoDotNet.Helpers
{
    public class UnderMaintenanceFilterAttribute : ActionFilterAttribute
    {
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

            bool.TryParse(ConfigurationManager.AppSettings["UnderMaintenance"], out underMaintenance);

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
