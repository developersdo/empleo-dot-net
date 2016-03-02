using System;
using System.Web;
using EmpleoDotNet.Core;

namespace EmpleoDotNet.Helpers
{
    public static class CookieHelper
    {
        private static HttpContextBase Context => EmpleoDotNetHttpContext.Current();

        public static void Set(string key, string value)
        {
            Context.Response.Cookies.Add(new HttpCookie(key) { Value = value});
        }

        public static string Get(string key)
        {
            var cookie = Context.Request.Cookies[key];
            return cookie != null ? Context.Server.HtmlEncode(cookie.Value).Trim() : String.Empty;
        }

        public static bool Exists(string key)
        {
            return Context.Request.Cookies[key] != null;
        }

        public static void Delete(string key)
        {
            if (Exists(key))
                Context.Response.Cookies.Add(new HttpCookie(key) { Expires = DateTime.Now.AddDays(-1) });
        }
    }
}