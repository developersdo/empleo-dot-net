using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EmpleoDotNet.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Extensión para los enums que permite obtener el display name del mismo.
        /// </summary>
        /// <param name="enumeration">Enum que se piensa extender</param>
        /// <returns></returns>
        public static string ToEnumDescription(this Enum enumeration)
        {
            var field = enumeration.GetType().GetFields()
                .FirstOrDefault(e => e.Name == Enum.GetName(enumeration.GetType(), enumeration));

            if (field == null)
                return "";
            var displayAttribute = field.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute == null)
                    throw new ArgumentException("Esta enumeración no posee el atributo display.");

            return field.GetCustomAttribute<DisplayAttribute>().Name;
        }

        public static IHtmlString EnumDropListFor<TModel, TEnum>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TEnum>> expression,
            object htmlAttributes = null)
        {
            IEnumerable<object> values = null;
            IEnumerable<SelectListItem> items = null;

            var meta = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var type = meta.ModelType ?? meta.ModelType;

            if (type != null)
                values = Enum.GetValues(type).Cast<object>();

            if (values != null)
                items = values.Where(e => e.GetType().GetField(e.ToString()).GetCustomAttribute<DisplayAttribute>() != null)
                    .Select(e => new SelectListItem {
                        Text = e.GetType().GetField(e.ToString()).GetCustomAttribute<DisplayAttribute>().Name,
                        Value = ((int)e).ToString(CultureInfo.InvariantCulture),
                        Selected = e.Equals(meta.Model)
                    });

            return helper.DropDownListFor(expression, items, htmlAttributes);
        }

    }
}