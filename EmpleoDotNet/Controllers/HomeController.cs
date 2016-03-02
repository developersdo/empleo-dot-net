using System.Web.Mvc;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.ViewModel;

namespace EmpleoDotNet.Controllers
{
    public class HomeController : EmpleoDotNetController
    {
        public ActionResult Index()
        {
            var model = new ViewModel.Home.IndexViewModel
            {
                LatestJobs = _jobOpportunityRepository.GetLatestJobOpportunity(7),
                SearchViewModel = new ViewModel.JobOpportunity.SearchViewModel
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