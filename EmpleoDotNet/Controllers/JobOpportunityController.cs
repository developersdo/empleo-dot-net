using System;
using System.Collections.Generic;
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
        // TODO: Hacer que el método sea más thin.
        public ActionResult Index(string selectedLocation = "", JobCategory jobCategory = JobCategory.None)
        {
            var locations = _locationRepository.GetAllLocationNames();

            const string placeholderLocations = "Todas las locaciones";
            
            locations.Insert(0, placeholderLocations);

            List<JobOpportunity> jobList; 

            if (!String.IsNullOrEmpty(selectedLocation) && !selectedLocation.Equals(placeholderLocations))
            {
                var locationArgument = _locationRepository.GetLocationByName(selectedLocation);

                jobList = jobCategory == JobCategory.None 
                    ? _jobRepository.GetAllJobOpportunitiesByLocation(locationArgument) 
                    : _jobRepository.GetAllJobOpportunitiesByLocationAndJobCategory(locationArgument, jobCategory);
            }
            else
            {
                jobList = jobCategory == JobCategory.None
                    ? _jobRepository.GetAllJobOpportunities()
                    : _jobRepository.GetAllJobOpportunitiesByJobCategory(jobCategory);
            }

            if (!jobList.Any())
                return RedirectToAction("Index", "Home");

            var vm = new JobOpportunitySearchViewModel
            {
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
                job.Locations = _locationRepository.GetAllLocations();
                ViewBag.ErrorMessage = "Han ocurrido errores de validación que no permiten continuar el proceso";
                return View(job);
            }

            _locationRepository.Add(new Location { Name = "Las Guaranas" });
            _jobRepository.Add(job.ToEntity());

            _uow.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult LastestsJob()
        {
            var latestJobOpportunities = _jobRepository.GetLatestJobOpporunity(10);

            return PartialView("_LastestJobs", latestJobOpportunities);
        }
    }
}
