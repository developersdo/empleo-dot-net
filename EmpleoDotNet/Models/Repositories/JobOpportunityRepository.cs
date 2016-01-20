using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.Models.Dto;
using PagedList;

namespace EmpleoDotNet.Models.Repositories
{
    public class JobOpportunityRepository : BaseRepository<JobOpportunity>, IJobOpportunityRepository
    {
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
            if (!id.HasValue) return null;

            return DbSet.Include(x => x.Location).FirstOrDefault(x => x.Id.Equals(id.Value));
        }

        /// <summary>
        /// Obtener una lista de Trabajos paginada por Ubicacion.
        /// </summary>
        /// <param name="parameter">Objeto con los parametros necesarios para realizar la consulta.</param>
        /// <returns>Objeto que representa una lista de datos paginados</returns>
        public IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter)
        {
            IPagedList<JobOpportunity> result = null;

            if (parameter.Page <= 0)
                parameter.Page = 1;

            if (parameter.PageSize <= 0)
                parameter.PageSize = 15;

            var jobs = DbSet.Include(x => x.Location).Where(x => x.IsRemote == parameter.IsRemote);

            if (parameter.JobCategory != JobCategory.All)
                jobs = jobs.Where(x => x.Category == parameter.JobCategory);

            jobs = jobs.OrderByDescending(x => x.Id);

            if (parameter.SelectedLocation <= 0)
            {
                if (!string.IsNullOrWhiteSpace(parameter.Keyword))
                    result = jobs.FullTextSearch(parameter.Keyword)
                        .ToPagedList(parameter.Page, parameter.PageSize);
                else
                    result = jobs.ToPagedList(parameter.Page, parameter.PageSize);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(parameter.Keyword))
                    result = jobs.Where(x => x.LocationId.Equals(parameter.SelectedLocation))
                        .FullTextSearch(parameter.Keyword)
                        .ToPagedList(parameter.Page, parameter.PageSize);
                else
                {
                    result = jobs
                        .Where(x => x.LocationId.Equals(parameter.SelectedLocation))
                        .ToPagedList(parameter.Page, parameter.PageSize);
                }
            }

            return result;
        }

        public List<JobOpportunity> GetLatestJobOpportunity(int quantity)
        {
            return GetAll().OrderByDescending(m => m.PublishedDate)
                .Include(m => m.Location)
                .Take(quantity)
                .ToList();
        }

        public JobOpportunityRepository(DbContext context):base(context)
        {
            
        }
    }
}