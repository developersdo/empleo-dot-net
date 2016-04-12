using System;
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

        public void UpdateJobOpportunity(int id, JobOpportunity updatedJob)
        {
            var existingJob = _jobOpportunityRepository.GetJobOpportunityById(id);

            existingJob.Title = updatedJob.Title;
            existingJob.Approved = updatedJob.Approved;
            existingJob.Category = updatedJob.Category;
            existingJob.CompanyEmail = updatedJob.CompanyEmail;
            existingJob.CompanyLogoUrl = updatedJob.CompanyLogoUrl;
            existingJob.CompanyName = updatedJob.CompanyName;
            existingJob.CompanyUrl = updatedJob.CompanyUrl;
            existingJob.Description = updatedJob.Description;
            existingJob.HowToApply = updatedJob.HowToApply;
            existingJob.IsActive = updatedJob.IsActive;
            existingJob.IsRemote = updatedJob.IsRemote;

            existingJob.JobOpportunityLikes = updatedJob.JobOpportunityLikes;
            existingJob.JobOpportunityLocation = updatedJob.JobOpportunityLocation;
            existingJob.JobOpportunityLocationId = updatedJob.JobOpportunityLocationId;

            existingJob.JobType = updatedJob.JobType;
            existingJob.JoelTest = updatedJob.JoelTest;
            existingJob.JoelTestId = updatedJob.JoelTestId;
            existingJob.Location = updatedJob.Location;
            existingJob.LocationId = updatedJob.LocationId;
            existingJob.Tags = updatedJob.Tags;

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

        public bool JobExists(int id)
        {
            return _jobOpportunityRepository.JobExists(id);
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