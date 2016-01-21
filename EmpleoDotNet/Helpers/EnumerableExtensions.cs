using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace EmpleoDotNet.Helpers
{
    /// <summary>
    /// Metodos extensores para IEnumerable
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Metodo Extensor que permite convertir un IEnumerable en un SelectList usando Expressions 
        /// </summary>
        /// <param name="list">Lista que se convertira al SelectList</param>
        /// <param name="valueProperty">Expression con la propiedad que contiene el Valor (key) en el SelectList</param>
        /// <param name="textProperty">Expression con la propiedad que contiene lo que se desplegara cuando se seleccione un elemento en el SelectList</param>
        /// <param name="selectedValue">Valor (key) que puede preseleccionarse a la hora de que se cargue el SelectList</param>
        /// <returns>MVC SelectList</returns>
        public static SelectList ToSelectList<T, TP1, TP2>(
            this IEnumerable<T> list, 
            Expression<Func<T, TP1>> valueProperty, 
            Expression<Func<T, TP2>> textProperty, 
            object selectedValue = null) where T : class
        {
            if (list == null)
                return null;

            var valueExpression = (MemberExpression)valueProperty.Body;
            var dataValueField = valueExpression.Member.Name;

            var textExpression = (MemberExpression)textProperty.Body;
            var dataTextField = textExpression.Member.Name;

            var result = new SelectList(list, dataValueField, dataTextField, selectedValue);

            return result;
        }
    }
}