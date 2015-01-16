using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.ViewModel
{
    public class JobOpportunitySearchViewModel
    {
        public IList<Models.JobOpportunity> JobOpportunities { get; set; }

        public int? SelectedLocationId { get; set; }
        
        public IList<EmpleoDotNet.Models.Location> Locations { get; set; }
    }
}