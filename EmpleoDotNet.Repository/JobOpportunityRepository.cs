using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.Repository.Dto;
using EmpleoDotNet.Repository.Helpers;
using PagedList;

namespace EmpleoDotNet.Repository
{
    public class JobOpportunityRepository : BaseRepository<JobOpportunity>, IJobOpportunityRepository
    {
        public List<JobOpportunity> GetAllJobOpportunities()
        {
            var jobOpportunities = DbSet
                .Include(x => x.JobOpportunityLocation)
                .OrderByDescending(x => x.PublishedDate);
            
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

        public bool JobExists(int id)
        {
            var job = DbSet.FirstOrDefault(m => m.Id == id);

            return job != null;
        }

        /// <summary>
        /// Obtener una lista de Empleos paginada por Ubicacion.
        /// </summary>
        /// <param name="parameter">Objeto con los parametros necesarios para realizar la consulta.</param>
        /// <returns>Objeto que representa una lista de datos paginados</returns>
        public IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter)
        {
            IPagedList<JobOpportunity> result = new PagedList<JobOpportunity>(null, 1, 15);

            if (parameter.Page <= 0)
                parameter.Page = 1;

            if (parameter.PageSize <= 0)
                parameter.PageSize = 15;

            var jobs = DbSet
                .Include(x => x.JobOpportunityLocation);

            jobs = jobs
                .OrderByDescending(x => x.Likes)
                .ThenByDescending(x => x.Id);
            
            //Filter by JobCategory
                jobs = jobs.Where(x => x.Category == parameter.JobCategory);

            if (parameter.IsRemote)
                jobs = jobs.Where(x => x.IsRemote);

            //Filter using FTS if keyword is not empty
            if (!string.IsNullOrWhiteSpace(parameter.Keyword))
                jobs = jobs.FullTextSearch(parameter.Keyword);

            //if no location selected just return pagination 
            if (string.IsNullOrWhiteSpace(parameter.SelectedLocationPlaceId))
            {
                result = jobs.ToPagedList(parameter.Page, parameter.PageSize);

                return result;
            }

            //Query using Haversine formula ref.: http://www.wikiwand.com/en/Haversine_formula

            var locations = GetNearbyJobOpportunityLocations(parameter.SelectedLocationLatitude,
                parameter.SelectedLocationLongitude, parameter.LocationDistance);

            if (!locations.Any())
                return result;

            result = (from jo in jobs
                where locations.Contains(jo.JobOpportunityLocationId.Value)
                select jo).ToPagedList(parameter.Page, parameter.PageSize);

            return result;
        }

        private List<int> GetNearbyJobOpportunityLocations(string latitude, string longitude, decimal distance)
        {
            var query =
                Context
                .Database
                .SqlQuery<NearbyJobOpportunityLocation>(@"
                    SELECT jol.Id
                    , p.distance_unit
                                * DEGREES(ACOS(COS(RADIANS(p.latpoint))
                                * COS(RADIANS(jol.Latitude))
                                * COS(RADIANS(p.longpoint) - RADIANS(jol.Longitude))
                                + SIN(RADIANS(p.latpoint))
                                * SIN(RADIANS(jol.Latitude)))) AS DistanceInKm
                FROM JobOpportunityLocations AS jol
                JOIN (   /* these are the query parameters */
                    SELECT  @latitude  AS latpoint, @longitude AS longpoint,
                            @distance AS radius, 111.045 AS distance_unit
                ) AS p ON 1=1
                WHERE jol.Latitude
                    BETWEEN p.latpoint  - (p.radius / p.distance_unit)
                        AND p.latpoint  + (p.radius / p.distance_unit)
                AND jol.longitude
                    BETWEEN p.longpoint - (p.radius / (p.distance_unit * COS(RADIANS(p.latpoint))))
                        AND p.longpoint + (p.radius / (p.distance_unit * COS(RADIANS(p.latpoint))))
                ORDER BY DistanceInKm ", 
                new SqlParameter("@latitude", latitude),
                new SqlParameter("@longitude", longitude),
                new SqlParameter("@distance", distance))
                .ToList();

            var result = query.Select(x => x.Id).ToList();
                
            return result;
        }

        public List<JobOpportunity> GetLatestJobOpportunity(int quantity)
        {
            return GetAll().OrderByDescending(m => m.PublishedDate)
                .ThenByDescending(x => x.Likes)
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