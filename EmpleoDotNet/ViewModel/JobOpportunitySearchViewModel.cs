using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.ViewModel
{
    public class JobOpportunitySearchViewModel
    {
        public IList<Models.JobOpportunity> JobOpportunities { get; set; }
        
        public string SelectedLocation { get; set; }
        
        public IList<string> Locations { get; set; }

        public JobCategory JobCategory { get; set; }
    }
}