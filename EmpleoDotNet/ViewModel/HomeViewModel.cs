using System.Collections.Generic;

namespace EmpleoDotNet.ViewModel
{
    public class HomeViewModel
    {
        public JobOpportunitySearchViewModel SearchPamameters { get; set; }
        public StatsViewModel Stats { get; set; }
        public List<Core.Domain.JobOpportunity> JobOpportunities { get; set; }
    }

    public class StatsViewModel
    {
        public int JobCount { get; set; }
        public int Visits { get; set; }
        public int CompanyCount { get; set; }
    }
}