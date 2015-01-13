using System;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Models;
using EmpleoDotNet.ViewModel;
using System.Collections.Generic;
using EmpleoDotNet.Models.Repositories;

namespace EmpleoDotNet.Controllers
{
    public class JobOpportunityController : Controller
    {
        private readonly Database _databaseContext;

        public JobOpportunityController()
        {
            _databaseContext = new Database();
        }
        
        // GET: /JobOpportunity/
        public ActionResult Index(string selectedLocation = "")
        {
            var jobRepository = new JobOpportunityRepository();
            var locationRepository = new LocationRepository();

            var jobList = jobRepository.GetAllJobOpportunities();

            var locations = locationRepository.GetAllLocationNames();

            var placeholderLocations = "Todas las locaciones";
            locations.Insert(0, placeholderLocations);

            if (!String.IsNullOrEmpty(selectedLocation) 
                && !selectedLocation.Equals(placeholderLocations))
            {
                var locationArgument = locationRepository.GetLocationByName(selectedLocation);

                jobList = jobRepository.GetAllJobOpportunitiesByLocation(locationArgument);
            }

            var vm = new JobOpportunitySearchViewModel {
                JobOpportunities = jobList,
                Locations = locations
            };

            if (!vm.JobOpportunities.Any())
                return RedirectToAction("Index", "Home");

            return View(vm);
        }

        // GET: /JobOpportunity/Detail/4
        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var vm = _databaseContext.JobOpportunities
                        .FirstOrDefault(d => d.Id == id);

            if (vm == null)
            {
                ViewBag.ErrorMessage = "La vacante solicitada no existe. " +
                                       "Por favor escoger una vacante válida del listado";
                return View("Index");
            }

            return View("Detail", vm);
        }

        // GET: /JobOpportunity/New
        public ActionResult New()
        {
            return View("New", new NewJobOpportunityViewModel());
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(NewJobOpportunityViewModel job)
        {
            if (!ModelState.IsValid)
            {
                @ViewBag.ErrorMessage = "Han ocurrido errores de validación que no permiten continuar el proceso";
                return View(job);
            }

            _databaseContext.JobOpportunities.Add(job.ToEntity());

            _databaseContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
