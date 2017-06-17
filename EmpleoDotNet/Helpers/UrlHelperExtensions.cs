using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Tweetinvi.Core.Extensions;

namespace EmpleoDotNet.Helpers
{
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Sanitiza un URL
        /// </summary>
        /// <remarks>http://stackoverflow.com/questions/6716832/sanitizing-string-to-url-safe-format</remarks>
        public static string SanitizeUrl(this string strToSanitize)
        {
            return strToSanitize == null
                ? null
                : Regex.Replace(strToSanitize, @"[^A-Za-z0-9_~]+", "-");
        }

        public static string SeoUrl(int id, string title)
        {
            return string.IsNullOrEmpty(title) ? id.ToString() : $"{id}-{SanitizeUrl(title)}";
        }

        public static bool IsValidImageUrl(string imageUrl)
        {
            var regex = new Regex("^(http|https)://(.+).(png|jpg)$");
            return !imageUrl.IsNullOrEmpty() && regex.IsMatch(imageUrl);
        }

        public static bool IsImageAvailable(string imageUrl)
        {
            if (!IsValidImageUrl(imageUrl)) return false;
            var request = WebRequest.Create(imageUrl);
            try
            {
                var response = (HttpWebResponse) request.GetResponse();
                var statusCode = response.StatusCode;
                response.Close();
                return statusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string AbsoluteUrl(this UrlHelper url, string actionName, string controllerName,
            object routeValues = null)
        {
            if (url.RequestContext.HttpContext.Request.Url == null) return null;
            var schema = url.RequestContext.HttpContext.Request.Url.Scheme;
            return url.Action(actionName, controllerName, routeValues, schema);
        }
    }   
}