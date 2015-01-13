using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.Models.Repositories
{
    public class JobOpportunityRepository:BaseRepository<JobOpportunity>, IJobOpportunityRepository
    {
        public List<JobOpportunity> GetAllJobOpportunities()
        {
            var jobOpportunities = GetAll().OrderByDescending(x => x.PublishedDate).ToList();

            return jobOpportunities ;
        }

        public List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location)
        {
            var jobOpportunities = GetAll().Where(x => x.LocationId == location.Id)
                                   .OrderByDescending(x => x.PublishedDate).ToList();

            return jobOpportunities;
        }

        public JobOpportunity GetJobOpportunityById(int id)
        {
            return GetById(id);
        }
    }
}