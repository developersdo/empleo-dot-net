using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.ViewModel;
using PagedList;

namespace EmpleoDotNet.Services
{
    public interface IJobOpportunityService
    {
        void CreateNewJobOpportunity(JobOpportunity jobOpportunity);
        List<RelatedJobDto> GetCompanyRelatedJobs(int id, string name, string email, string url);
        IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter);
        JobOpportunity GetJobOpportunityById(int? id);
        void UpdateViewCount(int id);
    }
}