using System;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Models;
using EmpleoDotNet.ViewModel;
using EmpleoDotNet.Models.Repositories;
using System.Collections.Generic;
using AutoMapper;

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
        public ActionResult Index(int? LocationId)
        {
            var jobList = _jobRepository.GetAllJobOpportunitiesByLocationId(LocationId);

            var locations = _locationRepository.GetAllLocations();

            ViewBag.LocationId = new SelectList(locations, "Id", "Name", LocationId);

            Mapper.CreateMap<JobOpportunity, JobOpportunityIndexViewModel>();
            var vm = Mapper.Map<IEnumerable<JobOpportunityIndexViewModel>>(jobList);
            
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

            _locationRepository.Add(new Location {Name = "Las Guaranas"});
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
