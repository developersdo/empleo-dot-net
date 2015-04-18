using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EmpleoDotNet.Models.Repositories
{
    public class JobOpportunityRepository : BaseRepository<JobOpportunity>, IJobOpportunityRepository
    {
        /// <summary>
        /// JobOportunities con su respectiva Location utilizando Eager Loading
        /// </summary>
        /// <returns></returns>
        private IQueryable<JobOpportunity> GetAllWithLocation()
        {
            return GetAll()
                .Include(j => j.Location);
        }

        public List<JobOpportunity> GetAllJobOpportunities()
        {
            //TODO: Este repositorio no debería instanciar otro
            var locationRepo = new LocationRepository(Context);
            var locations = locationRepo.GetAllLocations().ToDictionary(x=> x.Id);

            var jobOpportunities = GetAll().OrderByDescending(x => x.PublishedDate);
            
            //Esto es para llenar la propiedad de navegación ya que EF solo llena el LocationId (no se porqué)
            foreach (var item in jobOpportunities)
                item.Location = locations[item.LocationId];

            return jobOpportunities.ToList();
        }

        public List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location)
        {
            var jobOpportunities = GetAllJobOpportunities().Where(x => x.LocationId == location.Id).ToList();

            return jobOpportunities;
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

        public List<JobOpportunity> GetAllJobOpportunitiesByJobCategory(JobCategory category)
        {
            var jobList = GetAllWithLocation()
                .Where(j => j.Category == category)
                .OrderByDescending(j => j.PublishedDate)
                .ToList();

            return jobList;
        }

        public List<JobOpportunity> GetAllJobOpportunitiesByLocationAndJobCategory(Location location, JobCategory category)
        {
            var jobList = GetAllWithLocation()
                .Where(j => j.Category == category)
                .Where(j => j.LocationId == location.Id)
                .ToList();

            return jobList;
        }
    }
}