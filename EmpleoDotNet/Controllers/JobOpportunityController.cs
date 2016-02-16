using System.Threading.Tasks;
using System.Web.Mvc;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Services.Social.Twitter;
using EmpleoDotNet.ViewModel;
using EmpleoDotNet.ViewModel.JobOpportunity;
using reCAPTCHA.MVC;

namespace EmpleoDotNet.Controllers
{
    public class JobOpportunityController : EmpleoDotNetController
    {
        public ActionResult Index(JobOpportunityPagingParameter model)
        {
            var viewModel = GetSearchViewModel(model);

            var jobOpportunities = _jobOpportunityService.GetAllJobOpportunitiesPagedByFilters(model);

            viewModel.Result = jobOpportunities;

            return View(viewModel);
        }

        // GET: /JobOpportunity/Detail/4-jobtitle         
        public ActionResult Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("Index");

            var url = id.Split('-');

            if (url.Length == 0)
                return RedirectToAction("Index");

            var value = 0;

            if (!int.TryParse(url[0], out value))
                return RedirectToAction("Index");

            var vm = _jobOpportunityService.GetJobOpportunityById(value);

            if (vm != null)
            {
                var exceptedUrl = UrlHelperExtensions.SeoUrl(value, vm.Title.SanitizeUrl());

                if (!exceptedUrl.Equals(id))
                    return RedirectToActionPermanent("Detail", new { id = exceptedUrl });

                ViewBag.RelatedJobs =
                    _jobOpportunityService.GetCompanyRelatedJobs(value, vm.CompanyName);

                var cookieView = $"JobView{vm.Id}";
                if (!CookieHelper.Exists(cookieView))
                {
                    _jobOpportunityService.UpdateViewCount(vm.Id);
                    CookieHelper.Set(cookieView, vm.Id.ToString());
                }

                return View("Detail", vm);
            }

            ViewBag.ErrorMessage =
                "La vacante solicitada no existe. Por favor escoger una vacante válida del listado";

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var viewModel = new NewJobOpportunityViewModel();

            LoadLocations(viewModel);

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [CaptchaValidator(RequiredMessage = "Por favor confirma que no eres un robot")]
        public async Task<ActionResult> New(NewJobOpportunityViewModel model, bool captchaValid)
        {

            if (!ModelState.IsValid)
            {
                LoadLocations(model);
                ViewBag.ErrorMessage = "Han ocurrido errores de validación que no permiten continuar el proceso";
                return View(model);
            }

            var jobOpportunity = model.ToEntity();

            _jobOpportunityService.CreateNewJobOpportunity(jobOpportunity);

            await _twitterService.PostNewJobOpportunity(jobOpportunity);

            return RedirectToAction("detail", new { id = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title) });
        }

        public ActionResult Wizard()
        {
            var viewModel = new Wizard
            {
                Locations = _locationService.GetAllLocations().ToSelectList(x => x.Id, x => x.Name)
            };
            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Wizard(Wizard model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = _locationService.GetAllLocations().ToSelectList(x => x.Id, x => x.Name);
                ViewBag.ErrorMessage = "Han ocurrido errores de validación que no permiten continuar el proceso";
                return View(model);
            }
            var entity = model.ToEntity();
            _jobOpportunityService.CreateNewJobOpportunity(entity);
            return RedirectToAction("Detail", new { id = entity.Id, fromWizard = 1 });
        }

        private void LoadLocations(NewJobOpportunityViewModel viewModel)
        {
            var locations = _locationService.GetAllLocations();

            viewModel.Locations = locations.ToSelectList(x => x.Id, x => x.Name);
        }

        /// <summary>
        /// Transform JobOpportunityPagingParameter into JobOpportunitySearchViewModel with Locations
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private JobOpportunitySearchViewModel GetSearchViewModel(JobOpportunityPagingParameter model)
        {
            var locations = _locationService.GetLocationsWithDefault();

            var viewModel = new JobOpportunitySearchViewModel
            {
                Locations = locations.ToSelectList(l => l.Id, l => l.Name, model.SelectedLocation),
                SelectedLocation = model.SelectedLocation,
                JobCategory = model.JobCategory,
                Keyword = model.Keyword,
                IsRemote = model.IsRemote,
                CategoriesCount = _jobOpportunityService.GetMainJobCategoriesCount()
            };

            return viewModel;
        }

        public JobOpportunityController(
            ILocationService locationService,
            IJobOpportunityService jobOpportunityService,
            ITwitterService twitterService)
        {
            _locationService = locationService;
            _jobOpportunityService = jobOpportunityService;
            _twitterService = twitterService;
        }

        private readonly ILocationService _locationService;
        private readonly IJobOpportunityService _jobOpportunityService;
        private readonly ITwitterService _twitterService;
    }
}