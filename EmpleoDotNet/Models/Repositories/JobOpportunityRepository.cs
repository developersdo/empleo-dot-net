using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EmpleoDotNet.Models.Dto;

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
            return GetById(id);
        }

        /// <summary>
        /// Obtener una lista de Trabajos paginada por Ubicacion.
        /// </summary>
        /// <param name="parameter">Objeto con los parametros necesarios para realizar la consulta.</param>
        /// <returns>Objeto que representa una lista de datos paginados</returns>
        public PagedResult<JobOpportunity> GetAllJobOpportunitiesByLocationPaged(JobOpportunityPagingParameter parameter)
        {
            var result = new PagedResult<JobOpportunity>();

            if (parameter.Page <= 0)
            {
                parameter.Page = 1;
                result.Page = 1;
            }
            else
                result.Page = parameter.Page;

            if (parameter.PageSize <= 0)
            {
                parameter.PageSize = 15;
                result.PageSize = 15;
            }
            else
                result.PageSize = parameter.PageSize;

            if (parameter.SelectedLocation <= 0)
            {
                result.ItemCount = DbSet.Count();

                result.Items = DbSet.Include(x => x.Location)
                    .OrderBy(x => x.Id)
                    .Skip(parameter.PageSize*(parameter.Page - 1))
                    .Take(parameter.PageSize)
                    .ToList();
            }
            else
            {
                result.ItemCount = DbSet.Count(x => x.LocationId.Equals(parameter.SelectedLocation));

                result.Items = DbSet.Include(x => x.Location)
                    .Where(x => x.LocationId.Equals(parameter.SelectedLocation))
                    .OrderBy(x => x.Id)
                    .Skip(parameter.PageSize * (parameter.Page - 1))
                    .Take(parameter.PageSize)
                    .ToList();
            }

            return result;
        }

        public List<JobOpportunity> GetLatestJobOpporunity(int quantity)
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