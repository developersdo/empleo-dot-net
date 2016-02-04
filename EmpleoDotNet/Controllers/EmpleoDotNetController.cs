using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.Models;
using EmpleoDotNet.Models.Dto;
using EmpleoDotNet.Services;
using EmpleoDotNet.ViewModel;

namespace EmpleoDotNet.Controllers
{
    public abstract class EmpleoDotNetController : Controller
    {
        protected readonly DbContext _database;
        protected readonly IUnitOfWork _uow;

        protected EmpleoDotNetController()
        {
            _database = new EmpleadoContext();
            _uow = new EntityFrameworkUnitOfWork(_database);
        }

        public IList<JobCategoryLinkViewModel> GetPrimaryJobCategories()
        {
            var jobCategories = new List<JobCategory>()
            {
                JobCategory.MobileDevelopment,
                JobCategory.WebDevelopment,
                JobCategory.SoftwareDevelopment,
                JobCategory.GraphicDesign
            };

            var jobOpportunityService = new JobOpportunityService();

            var jobOpportunities = jobOpportunityService.GetJobOpportunitiesByCategories(jobCategories);

            var categories = new[]
            {
                new JobCategoryLinkViewModel
                {
                    JobCategory = JobCategory.MobileDevelopment,
                    JobQuantity = jobOpportunities.Count(x => x.Category == JobCategory.MobileDevelopment)
                },
                new JobCategoryLinkViewModel
                {
                    JobCategory = JobCategory.WebDevelopment,
                    JobQuantity = jobOpportunities.Count(x => x.Category == JobCategory.WebDevelopment)
                },
                new JobCategoryLinkViewModel
                {
                    JobCategory = JobCategory.SoftwareDevelopment,
                    JobQuantity = jobOpportunities.Count(x => x.Category == JobCategory.SoftwareDevelopment)
                },
                new JobCategoryLinkViewModel
                {
                    JobCategory = JobCategory.GraphicDesign,
                    JobQuantity = jobOpportunities.Count(x => x.Category == JobCategory.GraphicDesign)
                }
            };

            return categories;
        }
    }
}