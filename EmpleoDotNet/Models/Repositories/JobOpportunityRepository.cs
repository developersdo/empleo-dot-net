using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EmpleoDotNet.Models.Repositories
{
    public class JobOpportunityRepository : BaseRepository<JobOpportunity>, IJobOpportunityRepository
    {
        public JobOpportunityRepository(DbContext context) : base(context)
        {

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

        public IEnumerable<JobOpportunity> GetJobsPendingForApproval()
        {
            return GetAll().Where(m => m.Approved == null);
        }

        public void CanShowOnJobBoard(int jobId, bool canShow)
        {
            var job = GetJobOpportunityById(jobId);
            if (job == null) return;

            job.Approved = canShow;
            Context.SaveChanges();
        }
    }
}