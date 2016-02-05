using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Helpers
{
    public static class BoolExtensions
    {
        public static string ToYesNoString(this bool val)
        {
            return (val) ? "Si" : "No";
        }
    }
}