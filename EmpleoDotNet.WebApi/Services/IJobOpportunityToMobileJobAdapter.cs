﻿using Api.Contract;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.WebAPI.Helpers;

namespace EmpleoDotNet.WebAPI.Services
{
    public interface IJobOpportunityToMobileJobAdapter
    {
        JobCardDTO GetJobCard(JobOpportunity jobOpportunity);
        JobDetailResponse GetJobDetails(JobOpportunity jobOpportunity);
    }

    public class JobOpportunityToMobileJobAdapter : IJobOpportunityToMobileJobAdapter
    {
        public JobCardDTO GetJobCard(JobOpportunity jobOpportunity)
        {
            var jobCard = new JobCardDTO();
            jobCard.Employee = jobOpportunity.CompanyName;
            jobCard.IsRemote = jobOpportunity.IsRemote;
            jobCard.Job = jobOpportunity.Description;
            jobCard.JobType = jobOpportunity.JobType.GetDisplayName();
            jobCard.Link = jobOpportunity.Id.ToString();
            jobCard.Location = jobOpportunity.Location != null ? jobOpportunity.Location.Name : "N/A";

            return jobCard;
        }

        public JobDetailResponse GetJobDetails(JobOpportunity jobOpportunity)
        {
            var jobDetails = new JobDetailResponse();
            jobDetails.CompanyName = jobOpportunity.CompanyName;
            jobDetails.CompanyEmail = jobOpportunity.CompanyEmail;
            jobDetails.IsRemote = jobOpportunity.IsRemote;
            jobDetails.JobDescription = jobOpportunity.Description;
            jobDetails.JobTitle = jobOpportunity.Title;
            jobDetails.JobType = jobOpportunity.JobType.GetDisplayName();
            jobDetails.Link = jobOpportunity.Id.ToString();
            jobDetails.Location = jobOpportunity.Location != null ? jobOpportunity.Location.Name : "N/A";
            jobDetails.Visits = jobOpportunity.ViewCount;

            return jobDetails;
        }
    }
}