using System.Web.Mvc;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.ViewModel;

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

        public HomeController(IJobOpportunityRepository jobOpportunityRepository)
        {
            _jobOpportunityRepository = jobOpportunityRepository;
        }

        private readonly IJobOpportunityRepository _jobOpportunityRepository;
    }
}