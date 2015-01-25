using System;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Models;
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
        public ActionResult Index(string selectedLocation = "")
        {
            var jobList = _jobRepository.GetAllJobOpportunities();
            var locations = _locationRepository.GetAllLocationNames();

            const string placeholderLocations = "Todas las locaciones";
            locations.Insert(0, placeholderLocations);

            if (!String.IsNullOrEmpty(selectedLocation) && !selectedLocation.Equals(placeholderLocations))
            {
                var locationArgument = _locationRepository.GetLocationByName(selectedLocation);
                jobList = _jobRepository.GetAllJobOpportunitiesByLocation(locationArgument);
            }

            if (!jobList.Any())
                return RedirectToAction("Index", "Home");

            var vm = new JobOpportunitySearchViewModel {
                JobOpportunities = jobList,
                Locations = locations
            };

            return View(vm);
        }

        // GET: /JobOpportunity/Detail/4
        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var vm = _jobRepository.GetJobOpportunityById(id);

            if (vm != null) 
                return View("Detail", vm);
            
            ViewBag.ErrorMessage = 
                "La vacante solicitada no existe. Por favor escoger una vacante válida del listado";
            
            return View("Index");
        }

        // GET: /JobOpportunity/New
        public ActionResult New()
        {
            var viewModel = new NewJobOpportunityViewModel();
            viewModel.Locations = _locationRepository.GetAllLocations();

            return View("New", viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(NewJobOpportunityViewModel job)
        {
            if (!ModelState.IsValid)
            {
                var locationRepo = new LocationRepository();
                job.Locations = locationRepo.GetAllLocations();
                ViewBag.ErrorMessage = "Han ocurrido errores de validación que no permiten continuar el proceso";
                return View(job);
            }

            _jobRepository.Add(job.ToEntity());
            _uow.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
