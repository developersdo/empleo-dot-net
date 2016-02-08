﻿using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using PagedList;


namespace EmpleoDotNet.Repository.Contracts
{
    public interface IJobOpportunityRepository : IBaseRepository<JobOpportunity>
    {
        List<JobOpportunity> GetAllJobOpportunities();
        List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location);
        JobOpportunity GetJobOpportunityById(int? id);
        IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter);
        List<JobOpportunity> GetLatestJobOpportunity(int quantity);
        List<JobOpportunity> GetRelatedJobs(int id, string name, string email, string url);
    }
}
