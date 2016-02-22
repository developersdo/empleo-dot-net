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
            var jobOpportunities = DbSet.Include(x => x.JobOpportunityLocation).OrderByDescending(x => x.PublishedDate);
            
            return jobOpportunities.ToList();
        }

        public List<JobOpportunity> GetRelatedJobs(int id, string name)
        {
            var relatedJobs = DbSet
                .Where(
                    x =>
                        x.Id != id &&
                        (x.CompanyName.Equals(name,System.StringComparison.InvariantCultureIgnoreCase) 
                        )).OrderByDescending(x =>x.ViewCount)
                        .Take(5)
                        .ToList();

            return relatedJobs;
        }

        public List<JobCategoryCountDto> GetMainJobCategoriesCount()
        {
            var result = (from c in DbSet
                where (c.Category == JobCategory.MobileDevelopment ||
                       c.Category == JobCategory.SoftwareDevelopment ||
                       c.Category == JobCategory.WebDevelopment ||
                       c.Category == JobCategory.GraphicDesign)
                group c by new { c.Category} into g
                select new JobCategoryCountDto
                {
                    JobCategory = g.Key.Category,
                    Count = g.Count()
                }).ToList();

            return result;
        }

        public JobOpportunity GetJobOpportunityById(int? id)
        {
            if (!id.HasValue) return null;

            return DbSet.Include(x => x.JobOpportunityLocation)
                        .Include(x => x.JoelTest)
                        .FirstOrDefault(x => x.Id.Equals(id.Value));
        }

        /// <summary>
        /// Obtener una lista de Empleos paginada por Ubicacion.
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

            var jobs = DbSet.Include(x => x.JobOpportunityLocation);

            if (parameter.JobCategory != JobCategory.All)
                jobs = jobs.Where(x => x.Category == parameter.JobCategory);

            if (parameter.IsRemote)
                jobs = jobs.Where(x => x.IsRemote);

            jobs = jobs.OrderByDescending(x => x.Id);

            if (string.IsNullOrWhiteSpace(parameter.SelectedLocationPlaceId) && 
                string.IsNullOrWhiteSpace(parameter.SelectedLocationName))
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
                {
                    if (!string.IsNullOrWhiteSpace(parameter.SelectedLocationPlaceId))
                    {
                        result = jobs
                            .Where(x => x.JobOpportunityLocation.PlaceId.Equals(parameter.SelectedLocationPlaceId))
                            .FullTextSearch(parameter.Keyword)
                            .ToPagedList(parameter.Page, parameter.PageSize);
                    }
                    else if(!string.IsNullOrWhiteSpace(parameter.SelectedLocationName))
                    {
                        result = jobs
                            .Where(x => x.JobOpportunityLocation.Name.ToUpper()
                            .Contains(parameter.SelectedLocationName.ToUpper()))
                            .FullTextSearch(parameter.Keyword)
                            .ToPagedList(parameter.Page, parameter.PageSize);
                    }
                    else
                    {
                        result = jobs
                            .FullTextSearch(parameter.Keyword)
                            .ToPagedList(parameter.Page, parameter.PageSize);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(parameter.SelectedLocationPlaceId))
                    {
                        result = jobs
                            .Where(x => x.JobOpportunityLocation.PlaceId.Equals(parameter.SelectedLocationPlaceId))
                            .ToPagedList(parameter.Page, parameter.PageSize);
                    }
                    else if (!string.IsNullOrWhiteSpace(parameter.SelectedLocationName))
                    {
                        result = jobs
                            .Where(x => x.JobOpportunityLocation.Name.ToUpper()
                            .Contains(parameter.SelectedLocationName.ToUpper()))
                            .ToPagedList(parameter.Page, parameter.PageSize);
                    }
                }
            }

            return result;
        }

        public List<JobOpportunity> GetLatestJobOpportunity(int quantity)
        {
            return GetAll().OrderByDescending(m => m.PublishedDate)
                .Include(m => m.JobOpportunityLocation)
                .Take(quantity)
                .ToList();
        }

        public JobOpportunityRepository(EmpleadoContext context) 
            : base(context)
        {
        }
    }
}