using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var jobOpportunityService = new JobOpportunityService();

            var categories = new[]
            {
                new JobCategoryLinkViewModel
                {
                    JobCategory = JobCategory.MobileDevelopment,
                    JobQuantity = jobOpportunityService.GetJobOpportunitiesByCategory(JobCategory.MobileDevelopment).Count
                },
                new JobCategoryLinkViewModel
                {
                    JobCategory = JobCategory.WebDevelopment,
                    JobQuantity = jobOpportunityService.GetJobOpportunitiesByCategory(JobCategory.WebDevelopment).Count
                },
                new JobCategoryLinkViewModel
                {
                    JobCategory = JobCategory.SoftwareDevelopment,
                    JobQuantity = jobOpportunityService.GetJobOpportunitiesByCategory(JobCategory.SoftwareDevelopment).Count
                },
                new JobCategoryLinkViewModel
                {
                    JobCategory = JobCategory.GraphicDesign,
                    JobQuantity = jobOpportunityService.GetJobOpportunitiesByCategory(JobCategory.GraphicDesign).Count
                }
            };

            return categories;
        }
    }
}