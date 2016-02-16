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
        public static string ToCheckTimesString(this bool val)
        {
            return (val) ? "<i class='fa fa-check text-success'></i>" : "<i class='fa fa-times text-danger'></i>";
        }
    }
}