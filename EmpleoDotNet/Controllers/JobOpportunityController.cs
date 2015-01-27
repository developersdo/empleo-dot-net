﻿using System;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.ViewModel;
using EmpleoDotNet.Models.Repositories;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.Controllers
{
    public class JobOpportunityController : Controller
    {
        private readonly JobOpportunityRepository _jobRepository;
        private readonly LocationRepository _locationRepository;
        private readonly TagsRepository _tagsRepository;

        public JobOpportunityController()
        {
            _jobRepository = new JobOpportunityRepository();
            _locationRepository = new LocationRepository();
            _tagsRepository = new TagsRepository();
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
            _jobRepository.SaveChanges();

            string[] tagsStrings = job.Tag.Split(' ', ',');
            _tagsRepository.AddOrUpdateTag(tagsStrings);
            _tagsRepository.SaveChanges();
            

            return RedirectToAction("Index");
        }

        public ActionResult ViewTags()
        {
            var tagsList = _tagsRepository.GetAllTags();

            return View(tagsList);
        }

        public ActionResult JobsByTag(int id =1)
        {
            var tag = _tagsRepository.GetTagbByID(id);
            var jobsByTag = _tagsRepository.GetJobOportunitiesByTag(tag.TagName);

            return View(jobsByTag);
        }

    }
}
