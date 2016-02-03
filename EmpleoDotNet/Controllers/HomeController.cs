using System.Web.Mvc;
using EmpleoDotNet.Data;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.Repository;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.Services;
using EmpleoDotNet.ViewModel;

namespace EmpleoDotNet.Controllers
{
    public class HomeController : EmpleoDotNetController
    {
        private readonly ILocationService _locationService;
        private readonly IJobOpportunityRepository _jobOpportunityRepository;

        public HomeController()
            : this(new LocationService(), new JobOpportunityRepository(new EmpleadoContext()))
        {
        }

        public HomeController(
            ILocationService locationService,
            IJobOpportunityRepository jobOpportunityRepository)
        {
            _locationService = locationService;
            _jobOpportunityRepository = jobOpportunityRepository;
        }

        public ActionResult Index()
        {
            ViewBag.SearchViewModel = new JobOpportunitySearchViewModel
            {
                Locations = _locationService.GetLocationsWithDefault().ToSelectList(x => x.Id, x => x.Name)
            };

            var model = _jobOpportunityRepository.GetLatestJobOpportunity(7);
            return View(model);
        }
    }
}