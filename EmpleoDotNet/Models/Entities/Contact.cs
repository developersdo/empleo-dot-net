using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models.Entities
{
    public class Contact : Entity
    {
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String WebSite { get; set; }
    }
}