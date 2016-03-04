using System.Web.Mvc;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.ViewModel;
using EmpleoDotNet.ViewModel.Home;
using EmpleoDotNet.ViewModel.JobOpportunity;

namespace EmpleoDotNet.Controllers
{
    public class HomeController : EmpleoDotNetController
    {
        public ActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                LatestJobs = _jobOpportunityRepository.GetLatestJobOpportunity(7),
                SearchViewModel = new JobOpportunitySearchViewModel
                {
                    CategoriesCount = _jobOpportunityRepository.GetMainJobCategoriesCount()
                }
            };
            return View(model);
        }

        public HomeController(IJobOpportunityRepository jobOpportunityRepository)
        {
            _jobOpportunityRepository = jobOpportunityRepository;
        }

        private readonly IJobOpportunityRepository _jobOpportunityRepository;
    }
}