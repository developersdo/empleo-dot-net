using System.Web.Mvc;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.Repository;
using EmpleoDotNet.Services;
using EmpleoDotNet.ViewModel;

namespace EmpleoDotNet.Controllers
{
    public class HomeController : EmpleoDotNetController
    {
        private readonly JobOpportunityRepository _jobRepository;
        private readonly LocationService _locationService;

        public HomeController()
        {
            _jobRepository = new JobOpportunityRepository(_database);
            _locationService = new LocationService();
        }

        public ActionResult Index()
        {
            ViewBag.SearchViewModel = new JobOpportunitySearchViewModel
            {
                Locations = _locationService.GetLocationsWithDefault().ToSelectList(x => x.Id, x => x.Name)
            };

            var model = _jobRepository.GetLatestJobOpportunity(7);
            return View(model);
        }
    }
}