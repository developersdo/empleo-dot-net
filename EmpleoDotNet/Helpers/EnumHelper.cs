using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
                throw new ArgumentException("Esta enumeración no posee el atributo display.");

            return field.GetCustomAttribute<DisplayAttribute>().Name;
        }



        public static IHtmlString EnumDropListFor<TModel, TEnum>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TEnum>> expression,
            object htmlAttributes = null)
        {
            IEnumerable<SelectListItem> items = null;

            var meta = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var type = meta.ModelType ?? meta.ModelType;

            if (!typeof(Enum).IsAssignableFrom(type))
            {
                throw new ArgumentException("It is not Enum");
            }

            Debug.Assert(type != null, "type != null");

            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type).Cast<int>();

            items = names.Zip(values, (name, value) => new SelectListItem()
            {
                Text = name,
                Value = value.ToString(CultureInfo.InvariantCulture),
                Selected = value.Equals(meta.Model)
            });

            return helper.DropDownListFor(expression, items, string.Empty, htmlAttributes);
        }

    }
}