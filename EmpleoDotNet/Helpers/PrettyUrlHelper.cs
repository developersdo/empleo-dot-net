using System.Text.RegularExpressions;

namespace EmpleoDotNet.Helpers
{
    public static class PrettyUrlHelper
    {
        /// <summary>
        ///     Sanitizes a URL
        /// </summary>
        /// <remarks>http://stackoverflow.com/questions/6716832/sanitizing-string-to-url-safe-format</remarks>
        public static string SanitizeUrl(this string strThis)
        {
            if (strThis == null)
                return null;

            return Regex.Replace(strThis, @"[^A-Za-z0-9_~]+", "-");
        }
    }
}