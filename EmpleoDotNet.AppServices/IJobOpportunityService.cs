using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using PagedList;

namespace EmpleoDotNet.AppServices
{
    public interface IJobOpportunityService
    {
        void CreateNewJobOpportunity(JobOpportunity jobOpportunity, string userid);
        void UpdateJobOpportunity(int id, JobOpportunity updatedJob);
        void SoftDeleteJobOpportunity(JobOpportunity jobOpportunity);
        List<JobOpportunity> GetCompanyRelatedJobs(int id, string name);
        IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter);
        JobOpportunity GetJobOpportunityById(int? id);
        void UpdateViewCount(int id);
        List<JobCategoryCountDto> GetMainJobCategoriesCount();
        bool JobExists(int id);
    }
}