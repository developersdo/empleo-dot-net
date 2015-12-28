using System.Collections.Generic;
using EmpleoDotNet.Models.Dto;
using PagedList;

namespace EmpleoDotNet.Models.Repositories
{
    public interface IJobOpportunityRepository
    {
        List<JobOpportunity> GetAllJobOpportunities();
        List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location);
        JobOpportunity GetJobOpportunityById(int? id);
        IPagedList<JobOpportunity> GetAllJobOpportunitiesByLocationPaged(JobOpportunityPagingParameter parameter);
    }
}
