using System;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Models.UnitOfWork;
using EmpleoDotNet.ViewModel;
using EmpleoDotNet.Models.Repositories;

namespace EmpleoDotNet.Controllers
{
    public class JobOpportunityController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public JobOpportunityController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: /JobOpportunity/
        public ActionResult Index(string selectedLocation = "")
        {
            var jobList = _unitOfWork.JobOpportunityRepository.GetAllJobOpportunities();
            var locations = _unitOfWork.LocationRepository.GetAllLocationNames();

            const string placeholderLocations = "Todas las locaciones";
            locations.Insert(0, placeholderLocations);

            if (!String.IsNullOrEmpty(selectedLocation) && !selectedLocation.Equals(placeholderLocations))
            {
                var locationArgument = _unitOfWork.LocationRepository.GetLocationByName(selectedLocation);

                jobList = _unitOfWork.JobOpportunityRepository.GetAllJobOpportunitiesByLocation(locationArgument);

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

            var vm = _unitOfWork.JobOpportunityRepository.GetJobOpportunityById(id);

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

            viewModel.Locations = _unitOfWork.LocationRepository.GetAllLocations();

            return View("New", viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(NewJobOpportunityViewModel job)
        {
            if (!ModelState.IsValid)
            {
                job.Locations = _unitOfWork.LocationRepository.GetAllLocations();
                ViewBag.ErrorMessage = "Han ocurrido errores de validación que no permiten continuar el proceso";
                return View(job);
            }

            _unitOfWork.JobOpportunityRepository.Add(job.ToEntity());
            _unitOfWork.JobOpportunityRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool dispose)
        {
            _unitOfWork.Dispose();
            base.Dispose(dispose);
        }
    }
}
