using EmpleoDotNet.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpleoDotNet.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdministrationController : EmpleoDotNetController
    {
        private readonly JobOpportunityRepository _jobRepository;

        public AdministrationController()
        {
            _jobRepository = new JobOpportunityRepository(_database);
        }

        public ActionResult Index()
        {
            var jobsNotApproved = _jobRepository.GetJobsPendingForApproval();

            return View(jobsNotApproved);
        }

        [HttpPost]
        public void UpdateApprovalStatus(int jobId, bool canShow)
        {
            _jobRepository.CanShowOnJobBoard(jobId, canShow);
        }
    }
}