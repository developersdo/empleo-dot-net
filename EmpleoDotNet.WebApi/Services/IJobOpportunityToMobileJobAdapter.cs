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
            jobCard.CompanyLogoUrl = jobOpportunity.CompanyLogoUrl;
            jobCard.CompanyName = jobOpportunity.CompanyName;
            jobCard.Title = jobOpportunity.Title;
            // Maybe this should be left to the UI
            jobCard.PublishedDate = jobOpportunity.PublishedDate.GetValueOrDefault();
            jobCard.IsRemote = jobOpportunity.IsRemote;
            jobCard.Description = jobOpportunity.Description;
            jobCard.HowToApply = jobOpportunity.HowToApply;
            jobCard.JobType = jobOpportunity.JobType.GetDisplayName();
            jobCard.Link = jobOpportunity.Id.ToString();
            jobCard.ViewCount = jobOpportunity.ViewCount;
            jobCard.Likes = jobOpportunity.Likes;
            jobCard.Location = jobOpportunity.JobOpportunityLocation != null ? jobOpportunity.JobOpportunityLocation.Name : "N/A";
            

            return jobCard;
        }

        public JobDetailResponse GetJobDetails(JobOpportunity j)
        {
            var jd = new JobDetailResponse();
            jd.IsRemote = j.IsRemote;
            jd.JobDescription = j.Description;
            jd.JobTitle = j.Title;
            jd.JobType = j.JobType.GetDisplayName();
            jd.Link = j.Id.ToString();
            jd.Location = j.JobOpportunityLocation != null ? j.JobOpportunityLocation.Name: "N/A";
            jd.Visits = j.ViewCount;
            jd.HowToApply = j.HowToApply;
            jd.Company = new JobDetailResponse.JobDetailCompany()
            {
                Name = j.CompanyName,
                Email = j.CompanyEmail,
                LogoUrl = j.CompanyLogoUrl,
                Url = j.CompanyUrl
            };
            

            return jd;
        }
    }
}