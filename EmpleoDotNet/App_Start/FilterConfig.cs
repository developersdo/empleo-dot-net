using System.Web.Mvc;
using EmpleoDotNet.Helpers;

namespace EmpleoDotNet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Elmah.Contrib.Mvc.ElmahHandleErrorAttribute());
        }
    }
}
