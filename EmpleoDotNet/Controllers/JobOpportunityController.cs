using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.Models;
using EmpleoDotNet.Models.Dto;
using EmpleoDotNet.ViewModel;
using EmpleoDotNet.Models.Repositories;

namespace EmpleoDotNet.Controllers
{
    public class JobOpportunityController : EmpleoDotNetController
    {
        private readonly JobOpportunityRepository _jobRepository;
        private readonly LocationRepository _locationRepository;

        public JobOpportunityController()
        {
            _jobRepository = new JobOpportunityRepository(_database);
            _locationRepository = new LocationRepository(_database);
        }
        
        // GET: /JobOpportunity/
        public ActionResult Index(int selectedLocation = 0, string keyWord = "", int page = 1, int pageSize = 15)
        {
            var locations = _locationRepository.GetAllLocations();

            locations.Insert(0, new Location { Id = 0, Name = "Todas" });

            var viewModel = new JobOpportunitySearchViewModel
            {
                Locations = locations.ToSelectList(l => l.Id, l => l.Name, selectedLocation),
                SelectedLocation = selectedLocation,
                Keyword = keyWord
            };

            var jobOpportunities =
                _jobRepository.GetAllJobOpportunitiesByLocationAndFilterPaged(new JobOpportunityPagingParameter
                {
                    SelectedLocation = selectedLocation,
                    PageSize = pageSize,
                    Page = page,
                    Keyword = keyWord
                });

            viewModel.Result = jobOpportunities;
            ViewBag.SelectedLocation = selectedLocation;

            return View(viewModel);
        }

        // GET: /JobOpportunity/Detail/4
        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var vm = _jobRepository.GetJobOpportunityById(id);

            if (vm != null)
            {
                var relatedJobs =
                    _jobRepository.GetAllJobOpportunities()
                        .Where(
                            x =>
                                x.Id != vm.Id &&
                                (x.CompanyName == vm.CompanyName && x.CompanyEmail == vm.CompanyEmail &&
                                 x.CompanyUrl == vm.CompanyUrl)).Select(jobOpportunity => new RelatedJobDto()
                                 {
                                     Title = jobOpportunity.Title,
                                     Url = "/JobOpportunity/Detail/" + jobOpportunity.Id
                                 }).ToList();

                ViewBag.RelatedJobs = relatedJobs;

                return View("Detail", vm);
            }
                
            
            ViewBag.ErrorMessage = 
                "La vacante solicitada no existe. Por favor escoger una vacante válida del listado";
            
            return View("Index");
        }

        // GET: /JobOpportunity/New
        public ActionResult New()
        {
            var viewModel = new NewJobOpportunityViewModel();

            LoadLocations(viewModel);

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult New(NewJobOpportunityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadLocations(model);
                ViewBag.ErrorMessage = "Han ocurrido errores de validación que no permiten continuar el proceso";
                return View(model);
            }

            _jobRepository.Add(model.ToEntity());

            _uow.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult LastestsJob()
        {
            var latestJobOpportunities = _jobRepository.GetLatestJobOpportunity(10);

            return PartialView("_LastestJobs", latestJobOpportunities);
        }

        private void LoadLocations(NewJobOpportunityViewModel viewModel)
        {
            var locations = _locationRepository.GetAllLocations();

            viewModel.Locations = locations.ToSelectList(x => x.Id, x => x.Name);
        }
    }
}