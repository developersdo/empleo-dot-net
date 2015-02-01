using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Helpers
{
    public class PrettyUrlHelper
    {
        public static string Beautify(string str)
        {
            //TODO: Este método es solo una demostración. Hay que implementarlo mejor
            return str.ToLower()
                .Replace(".","")
                .Replace(",", "")
                .Replace(" ", "-")
                .Replace("ñ", "n")
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u");
        }
    }
}