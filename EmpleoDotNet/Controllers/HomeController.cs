using System.Web.Mvc;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.ViewModel;

namespace EmpleoDotNet.Controllers
{
    public class HomeController : EmpleoDotNetController
    {
        public ActionResult Index()
        {
            ViewBag.SearchViewModel = new JobOpportunitySearchViewModel {
                Locations = _locationService.GetLocationsWithDefault().ToSelectList(x => x.Id, x => x.Name)
            };

            var model = _jobOpportunityRepository.GetLatestJobOpportunity(7);
            return View(model);
        }

        public HomeController(
            ILocationService locationService,
            IJobOpportunityRepository jobOpportunityRepository)
        {
            _locationService = locationService;
            _jobOpportunityRepository = jobOpportunityRepository;
        }

        private readonly ILocationService _locationService;
        private readonly IJobOpportunityRepository _jobOpportunityRepository;
    }
}