using EmpleoDotNet.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpleoDotNet.Controllers
{
    public class HomeController : EmpleoDotNetController
    {
        private readonly JobOpportunityRepository _jobRepository;

        public HomeController()
        {
            _jobRepository = new JobOpportunityRepository(_database);
        }

        public ActionResult Index()
        {
            var latestJobOpportunities = _jobRepository.GetLatestJobOpporunity(10);

            return View(latestJobOpportunities);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}