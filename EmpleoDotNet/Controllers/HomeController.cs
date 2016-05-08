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
            ViewBag.SearchViewModel = new JobOpportunitySearchViewModel {
                CategoriesCount = _jobOpportunityRepository.GetMainJobCategoriesCount()
            };

            var model = _jobOpportunityRepository.GetLatestJobOpportunity(7);
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