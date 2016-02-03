using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using PagedList;


namespace EmpleoDotNet.Repository.Contracts
{
    public interface IJobOpportunityRepository
    {
        List<JobOpportunity> GetAllJobOpportunities();
        List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location);
        JobOpportunity GetJobOpportunityById(int? id);
        IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter);
    }
}
