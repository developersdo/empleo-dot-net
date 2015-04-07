using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EmpleoDotNet.Models.Repositories
{
    public class JobOpportunityRepository : BaseRepository<JobOpportunity>, IJobOpportunityRepository
    {
        public List<JobOpportunity> GetAllJobOpportunities()
        {
            //TODO: Este repositorio no debería instanciar otro
            var locationRepo = new LocationRepository(Context);

            var jobOpportunities = GetAll().Include(j => j.Location)
                .OrderByDescending(x => x.PublishedDate);          

            return jobOpportunities.ToList();
        }

        public List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location)
        {
            var jobOpportunities = GetAllJobOpportunities().Where(x => x.LocationId == location.Id).ToList();

            return jobOpportunities;
        }
        public List<JobOpportunity> GetAllJobOpportunitiesByLocationId(int? locationId)
        {
            var jobOpportunities = GetAll().Include(x => x.Location)
                .Where(j => j.LocationId == locationId
                || locationId == null);
            
            return jobOpportunities.ToList();
        }

        public JobOpportunity GetJobOpportunityById(int? id)
        {
            return GetById(id);
        }

        public List<JobOpportunity> GetLatestJobOpporunity(int quantity)
        {
            return GetAll().OrderByDescending(m => m.PublishedDate)
                .Include(m => m.Location)
                .Take(quantity)
                .ToList();
        }

        public JobOpportunityRepository(DbContext context)
        {
            this.Context = context;
        }
    }
}