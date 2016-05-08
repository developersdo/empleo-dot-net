using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.Services;
using EmpleoDotNet.ViewModel;
using System.Collections.Generic;
using EmpleoDotNet.Helpers;

namespace EmpleoDotNet.Controllers
{
    public class HomeController : EmpleoDotNetController
    {
        public ActionResult Index()
        {
            var allJobOpportunities = _jobOpportunityRepository.GetAllJobOpportunities();

            var model = new HomeViewModel();

            var jobCount = allJobOpportunities.Count;

            var visits = allJobOpportunities.Sum(x => x.ViewCount);

            var companyCount = (from jo in allJobOpportunities
                group jo by jo.CompanyName
                into grp
                select new {Count = grp.Count()}).Count();

            model.SearchPamameters = new JobOpportunitySearchViewModel
            {
                CategoriesCount = _jobOpportunityRepository.GetMainJobCategoriesCount()
            };

            model.Stats = new StatsViewModel
            {
                JobCount = jobCount,
                Visits = visits,
                CompanyCount = companyCount
            };

            model.JobOpportunities = allJobOpportunities.OrderByDescending(x => x.Id).Take(7).ToList();

            return View(model);
        }

        public ActionResult Rss()
        {         
            var model = _jobOpportunityRepository.GetLatestJobOpportunity(7);
            return new RssResult(Constants.RssTitle, Constants.RssDescription, model.ToSyndicationList());
        }

        public HomeController(IJobOpportunityRepository jobOpportunityRepository)
        {
            _jobOpportunityRepository = jobOpportunityRepository;
        }

        private readonly IJobOpportunityRepository _jobOpportunityRepository;
    }
}