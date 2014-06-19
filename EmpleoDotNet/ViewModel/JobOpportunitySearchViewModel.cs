using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.ViewModel
{
    public class JobOpportunitySearchViewModel
    {
        public IList<Models.JobOpportunity> JobOpportunities { get; set; }
        
        public string SelectedLocation { get; set; }
        
        public IList<string> Locations { get; set; }
    }
}