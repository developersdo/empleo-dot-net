using System.Collections.Generic;
using System.Linq;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.AppServices.ViewModel;
using PagedList;

namespace EmpleoDotNet.AppServices
{
    public class JobOpportunityService : IJobOpportunityService
    {
        public void CreateNewJobOpportunity(JobOpportunity jobOpportunity)
        {
            _jobOpportunityRepository.Add(jobOpportunity);
            _jobOpportunityRepository.SaveChanges();
        }

        public List<JobOpportunity> GetCompanyRelatedJobs(int id, string name, string email, string url)
        {
            var result = _jobOpportunityRepository.GetRelatedJobs(id,name, email, url);

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


        public JobOpportunityService(
            IJobOpportunityRepository jobOpportunityRepository
            )
        {
            _jobOpportunityRepository = jobOpportunityRepository;
        }

        private readonly IJobOpportunityRepository _jobOpportunityRepository;
    }
}