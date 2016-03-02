using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpleoDotNet.ViewModel.JobOpportunity;

namespace EmpleoDotNet.ViewModel.Home
{
    public class IndexViewModel
    {
        public IEnumerable<EmpleoDotNet.Core.Domain.JobOpportunity> LatestJobs { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
    }
}