using System.Collections.Generic;
using System.Linq;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Repository.Contracts;
using PagedList;

namespace EmpleoDotNet.AppServices
{
    public class JobOpportunityService : IJobOpportunityService
    {
        public void CreateNewJobOpportunity(JobOpportunity jobOpportunity, string userid)
        {
            jobOpportunity.UserProfile = _userProfileRepository.GetByUserId(userid);
            _jobOpportunityRepository.Add(jobOpportunity);
            _jobOpportunityRepository.SaveChanges();
        }

        public List<JobOpportunity> GetCompanyRelatedJobs(int id, string name)
        {
            var result = _jobOpportunityRepository.GetRelatedJobs(id,name);

            return result;
        }

        public IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter)
        {
            return _jobOpportunityRepository.GetAllJobOpportunitiesPagedByFilters(parameter);
        }

        public JobOpportunity GetJobOpportunityById(int? id)
        {
            return _jobOpportunityRepository.GetJobOpportunityById(id);
        }

        public void UpdateViewCount(int id)
        {
            var item = _jobOpportunityRepository.GetJobOpportunityById(id);

            if (item == null) return;

            item.ViewCount++;
            _jobOpportunityRepository.SaveChanges();           
        }

        public List<JobCategoryCountDto> GetMainJobCategoriesCount()
        {
            return _jobOpportunityRepository.GetMainJobCategoriesCount();
        }


        public JobOpportunityService(
            IJobOpportunityRepository jobOpportunityRepository,
            IUserProfileRepository userProfileRepository
            )
        {
            _jobOpportunityRepository = jobOpportunityRepository;
            _userProfileRepository = userProfileRepository;
        }

        private readonly IJobOpportunityRepository _jobOpportunityRepository;
        private readonly IUserProfileRepository _userProfileRepository;
    }
}