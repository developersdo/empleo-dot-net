using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;

namespace EmpleoDotNet.Helpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Obtiene la versión del assembly actual como un string
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString AssemblyVersion(this HtmlHelper helper)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return MvcHtmlString.Create(version);
        }

        /// <summary>
        /// Agrega la clase active al elemento dependiendo de la ruta en la que este
        /// </summary>
        /// <param name="html"></param>
        /// <param name="controllers"></param>
        /// <param name="actions"></param>
        /// <param name="cssClass"></param>
        /// <returns> string cssClass</returns>
        public static string IsSelected(this HtmlHelper html, string controllers = "", string actions = "", string cssClass = "active")
        {
            ViewContext viewContext = html.ViewContext;
            bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

            if (isChildAction)
            {
                viewContext = html.ViewContext.ParentActionViewContext;
            }

            RouteValueDictionary routeValues = viewContext.RouteData.Values;
            string currentAction = routeValues["action"].ToString();
            string currentController = routeValues["controller"].ToString();

            if (String.IsNullOrEmpty(actions))
            {
                actions = currentAction;
            }

            if (String.IsNullOrEmpty(controllers))
            {
                controllers = currentController;
            }

            string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
            string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

            if (acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController))
            {
                return cssClass;
            }
            return string.Empty;
        }
        /// <summary>
        /// Obtener de las dos primemras palabras su primera letra. Sí el texto solo posee una palabra solo se retorna la primera letra de la misma
        /// </summary>
        /// <param name="helper">Variable de extensión</param>
        /// <param name="value">Valor a procesar</param>
        /// <returns>HtmlString</returns>
        public static IHtmlString FirstTwoLetters(this HtmlHelper helper, string value)
        {
            var splited = Regex.Split(value, @"[_+-.,!@#$%^&*();\/|<> ]|[0-9]");
            var result = string.Empty;

            foreach (var currentValue in splited)
            {
                if(string.IsNullOrWhiteSpace(currentValue))continue;

                result += currentValue.Substring(0, 1);

                if(result.Length.Equals(2))
                    break;
            }

            return MvcHtmlString.Create(result);
        }
    }
}