using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EmpleoDotNet.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString AssemblyVersion(this HtmlHelper helper)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return MvcHtmlString.Create(version);
        }
    }
}