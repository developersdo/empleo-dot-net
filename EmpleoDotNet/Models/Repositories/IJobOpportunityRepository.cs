using System.Collections.Generic;
using EmpleoDotNet.Models.Dto;

namespace EmpleoDotNet.Models.Repositories
{
    public interface IJobOpportunityRepository
    {
        List<JobOpportunity> GetAllJobOpportunities();
        List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location);
        JobOpportunity GetJobOpportunityById(int? id);
        PagedResult<JobOpportunity> GetAllJobOpportunitiesByLocationPaged(JobOpportunityPagingParameter parameter);
    }
}
