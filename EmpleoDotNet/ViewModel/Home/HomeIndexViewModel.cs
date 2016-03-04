using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpleoDotNet.ViewModel.JobOpportunity;

namespace EmpleoDotNet.ViewModel.Home
{
    public class HomeIndexViewModel
    {
        public IEnumerable<EmpleoDotNet.Core.Domain.JobOpportunity> LatestJobs { get; set; }
        public JobOpportunitySearchViewModel SearchViewModel { get; set; }
    }
}