using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

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

    }
}