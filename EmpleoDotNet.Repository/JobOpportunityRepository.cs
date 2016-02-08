using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.Repository.Helpers;
using PagedList;

namespace EmpleoDotNet.Repository
{
    public class JobOpportunityRepository : BaseRepository<JobOpportunity>, IJobOpportunityRepository
    {
        public List<JobOpportunity> GetAllJobOpportunities()
        {
            var jobOpportunities = DbSet.Include(x=>x.Location).OrderByDescending(x => x.PublishedDate);
            
            return jobOpportunities.ToList();
        }

        public List<JobOpportunity> GetAllJobOpportunitiesByLocation(Location location)
        {
            var jobOpportunities = DbSet.Include(x => x.Location).Where(x => x.LocationId == location.Id).ToList();

            return jobOpportunities;
        }

        public List<JobOpportunity> GetRelatedJobs(int id, string name, string email, string url)
        {
            var RelatedJobs = DbSet.Take(5)
                .Where(
                    x =>
                        x.Id != id &&
                        (x.CompanyName == name && x.CompanyEmail == email &&
                         x.CompanyUrl == url)).OrderByDescending(x =>x.ViewCount).ToList();

            return RelatedJobs;
        }

        public JobOpportunity GetJobOpportunityById(int? id)
        {
            if (!id.HasValue) return null;
            return DbSet.Include(x => x.Location).Include(x=>x.JoelTest).FirstOrDefault(x => x.Id.Equals(id.Value));
        }

        /// <summary>
        /// Obtener una lista de Empleos paginada por Ubicacion.
        /// </summary>
        /// <param name="parameter">Objeto con los parametros necesarios para realizar la consulta.</param>
        /// <returns>Objeto que representa una lista de datos paginados</returns>
        public IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter)
        {
            IPagedList<JobOpportunity> result;

            if (parameter.Page <= 0)
                parameter.Page = 1;

            if (parameter.PageSize <= 0)
                parameter.PageSize = 15;

            var jobs = DbSet.Include(x => x.Location);

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

        public JobOpportunityRepository(EmpleadoContext context) 
            : base(context)
        {
        }
    }
}