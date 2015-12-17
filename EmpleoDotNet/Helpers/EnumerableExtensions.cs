using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace EmpleoDotNet.Helpers
{
    public static class EnumerableExtensions
    {
        public static SelectList ToSelectList<T, TP1, TP2>(this IEnumerable<T> list, Expression<Func<T, TP1>> valueProperty, Expression<Func<T, TP2>> textProperty, object selectedValue = null) where T : class
        {
            var valueExpression = (MemberExpression)valueProperty.Body;
            var dataValueField = valueExpression.Member.Name;

            var textExpression = (MemberExpression)textProperty.Body;
            var dataTextField = textExpression.Member.Name;

            var result = new SelectList(list, dataValueField, dataTextField, selectedValue);

            return result;
        }
    }
}