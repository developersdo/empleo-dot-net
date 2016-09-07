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

            if (updatedJob.JobOpportunityLocation != null)
            {
                existingJob.JobOpportunityLocation = existingJob.JobOpportunityLocation == null
                    ? new JobOpportunityLocation()
                    : existingJob.JobOpportunityLocation;

                existingJob.JobOpportunityLocation.Latitude = updatedJob.JobOpportunityLocation.Latitude;
                existingJob.JobOpportunityLocation.Longitude = updatedJob.JobOpportunityLocation.Longitude;
                existingJob.JobOpportunityLocation.Name = updatedJob.JobOpportunityLocation.Name;
                existingJob.JobOpportunityLocation.PlaceId = updatedJob.JobOpportunityLocation.PlaceId;
            }

            existingJob.JobType = updatedJob.JobType;
            if (updatedJob.JoelTest != null)
            {
                existingJob.JoelTest = existingJob.JoelTest == null
                    ? new JoelTest()
                    : existingJob.JoelTest;

                existingJob.JoelTest.HasBestTools = updatedJob.JoelTest.HasBestTools;
                existingJob.JoelTest.HasBugDatabase = updatedJob.JoelTest.HasBugDatabase;
                existingJob.JoelTest.HasBusFixedBeforeProceding = updatedJob.JoelTest.HasBusFixedBeforeProceding;
                existingJob.JoelTest.HasDailyBuilds = updatedJob.JoelTest.HasDailyBuilds;
                existingJob.JoelTest.HasHallwayTests = updatedJob.JoelTest.HasHallwayTests;
                existingJob.JoelTest.HasOneStepBuilds = updatedJob.JoelTest.HasOneStepBuilds;
                existingJob.JoelTest.HasQuiteEnvironment = updatedJob.JoelTest.HasQuiteEnvironment;
                existingJob.JoelTest.HasSourceControl = updatedJob.JoelTest.HasSourceControl;
                existingJob.JoelTest.HasSpec = updatedJob.JoelTest.HasSpec;
                existingJob.JoelTest.HasTesters = updatedJob.JoelTest.HasTesters;
                existingJob.JoelTest.HasUpToDateSchedule = updatedJob.JoelTest.HasUpToDateSchedule;
                existingJob.JoelTest.HasWrittenTest = updatedJob.JoelTest.HasWrittenTest;
            }

            _jobOpportunityRepository.SaveChanges();

        }

        public void SoftDeleteJobOpportunity(JobOpportunity jobOpportunity)
        {
            jobOpportunity.IsActive = false;
            _jobOpportunityRepository.SaveChanges();
        }

        public void ToggleHideState(JobOpportunity jobOpportunity)
        {
            jobOpportunity.IsHidden = !jobOpportunity.IsHidden;
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
            var jobOpportunity = _jobOpportunityRepository.GetJobOpportunityById(id);

            if (jobOpportunity == null) return;

            jobOpportunity.ViewCount++;
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

        public void CreateNewReaction(int jobOpportunityId, bool like)
        {
            var job = _jobOpportunityRepository.GetJobOpportunityById(jobOpportunityId);
            if (job == null) return;
            if (like) job.Likes++;
            else job.DisLikes++;
            _jobOpportunityRepository.SaveChanges();
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