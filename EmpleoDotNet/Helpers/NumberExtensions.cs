using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Helpers
{
    public static class NumberExtensions
    {
        public static string FormatThousand(this int number)
        {
            return string.Format(number.ToString(), "{1:#,0}");
        }
    }
}