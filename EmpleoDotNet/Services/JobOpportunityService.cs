using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EmpleoDotNet.Models;
using EmpleoDotNet.Models.Dto;
using EmpleoDotNet.Models.Repositories;
using EmpleoDotNet.ViewModel;
using PagedList;

namespace EmpleoDotNet.Services
{
    public class JobOpportunityService
    {
        private readonly JobOpportunityRepository _jobOpportunityRepository;

        public JobOpportunityService()
        {
            _jobOpportunityRepository = new JobOpportunityRepository(new EmpleadoContext());
        }

        public void CreateNewJobOpportunity(JobOpportunity jobOpportunity)
        {
            _jobOpportunityRepository.Add(jobOpportunity);
            _jobOpportunityRepository.SaveChanges();
        }

        public List<RelatedJobDto> GetCompanyRelatedJobs(int id, string name, string email, string url)
        {
            var result = _jobOpportunityRepository.GetAllJobOpportunities()
                .Where(
                    x =>
                        x.Id != id &&
                        (x.CompanyName == name && x.CompanyEmail == email &&
                         x.CompanyUrl == url))
                .Select(jobOpportunity => new RelatedJobDto
                {
                    Title = jobOpportunity.Title,
                    Url = "/JobOpportunity/Detail/" + jobOpportunity.Id
                }).ToList();

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

        public IList<JobOpportunity> GetJobOpportunitiesByCategories(IList<JobCategory> jobCategories)
        {
            return _jobOpportunityRepository.GetAllJobOpportunities()
                .Where(x => jobCategories.Contains(x.Category))
                .ToList();
        }
    }
}