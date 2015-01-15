using System.Collections.Generic;

namespace EmpleoDotNet.Models.Repositories
{
    public interface IJobOpportunityRepository
    {
        List<JobOpportunity> GetAllJobOpportunities();
        List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location);
        JobOpportunity GetJobOpportunityById(int? id);
    }
}
