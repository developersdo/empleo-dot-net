using System;
using System.Web;

namespace EmpleoDotNet.Core
{
    /// <summary>
    /// An wrapper around HttpContext.Current that helps with unit testing.
    /// </summary>
    public static class EmpleoDotNetHttpContext
    {
        public static Func<HttpContextBase> Current = () => {
            var context = HttpContext.Current;
            return context != null ? new HttpContextWrapper(context) : null;
        };
    }
}