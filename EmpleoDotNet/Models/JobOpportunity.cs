using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models
{
    public enum eCategory
    {
        None = 0,
        GraphicDesign = 1,
        WebDevelopment = 2,
        MobileApplication = 3,
        SoftwareDevelopment = 4,
        SystemAdministrator = 5,
        Networking = 6,
        Sales = 7
    }

    public class JobOpportunity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public eCategory Category { get; set; }
        public string Location { get; set; }
        public Company Company { get; set; }        
    }
}