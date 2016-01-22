using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Helpers
{
    public static class CookieHelper
    {
        private static HttpContext _context { get { return HttpContext.Current; } }

        public static void Set(string key, string value)
        {
            _context.Response.Cookies.Add(new HttpCookie(key) { Value = value});
        }

        public static string Get(string key)
        {
            var value = string.Empty;
            var c = _context.Request.Cookies[key];
            return c != null ? _context.Server.HtmlEncode(c.Value).Trim() : value;
        }

        public static bool Exists(string key)
        {
            return _context.Request.Cookies[key] != null;
        }

        public static void Delete(string key)
        {
            if (Exists(key))
            {
                var c = new HttpCookie(key)
                { Expires = DateTime.Now.AddDays(-1) };
                _context.Response.Cookies.Add(c);
            }
        }
    }
}