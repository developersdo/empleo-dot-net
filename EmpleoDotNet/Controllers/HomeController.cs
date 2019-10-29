using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.Services;
using EmpleoDotNet.ViewModel;
using System.Collections.Generic;
using EmpleoDotNet.Helpers;
using System.Configuration;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Controllers
{
    public class HomeController : EmpleoDotNetController
    {
        public ActionResult Index()
        {
            ViewBag.SearchViewModel = new JobOpportunitySearchViewModel {
                CategoriesCount = _jobOpportunityRepository.GetMainJobCategoriesCount()
            };

            return View(GetRecentJobs());
        }

        public ActionResult Rss()
        {         
            var model = GetRecentJobs();
            return new RssResult(Constants.RssTitle, Constants.RssDescription, model.ToSyndicationList());
        }

        private IList<JobOpportunity> GetRecentJobs()
        {
            int howMany;
            int defaultCount = 7;
            if (int.TryParse(ConfigurationManager.AppSettings["HomeController:RecentJobCount"], out howMany))
            {
                defaultCount = howMany;
            }

            var model = _jobOpportunityRepository.GetLatestJobOpportunity(defaultCount);
            return model;
        }

        public HomeController(IJobOpportunityRepository jobOpportunityRepository)
        {
            _jobOpportunityRepository = jobOpportunityRepository;
        }

        private readonly IJobOpportunityRepository _jobOpportunityRepository;
    }
}