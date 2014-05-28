using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
    }
}