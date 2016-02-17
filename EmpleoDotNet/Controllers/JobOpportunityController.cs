using System.Threading.Tasks;
using System.Web.Mvc;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Helpers.Alerts;
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

            return View("Index").WithError("La vacante solicitada no existe. Por favor escoge una vacante válida del listado");
        }

        public ActionResult New()
        {
            var viewModel = new NewJobOpportunityViewModel();

            return View(viewModel)
                .WithInfo("Prueba nuestro nuevo proceso guiado de creación de posiciones haciendo <b><a href='"+Url.Action("Wizard")+"'>click aquí</a></b>");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [CaptchaValidator(RequiredMessage = "Por favor confirma que no eres un robot")]
        public async Task<ActionResult> New(NewJobOpportunityViewModel model, bool captchaValid)
        {
            if (!ModelState.IsValid)
            {
                return View(model)
                    .WithError("Han ocurrido errores de validación que no permiten continuar el proceso");
            }

            var jobOpportunity = model.ToEntity();

            _jobOpportunityService.CreateNewJobOpportunity(jobOpportunity);

            await _twitterService.PostNewJobOpportunity(jobOpportunity);

            return RedirectToAction("Detail", new
            {
                id = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title)
            });
        }

        public ActionResult Wizard()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [CaptchaValidator(RequiredMessage = "Por favor confirma que no eres un robot")]
        public async Task<ActionResult> Wizard(Wizard model)
        {
            if (!ModelState.IsValid)
                return View(model)
                    .WithError("Han ocurrido errores de validación que no permiten continuar el proceso");

            var jobOpportunity = model.ToEntity();

            _jobOpportunityService.CreateNewJobOpportunity(jobOpportunity);

            await _twitterService.PostNewJobOpportunity(jobOpportunity);

            return RedirectToAction("Detail", new
            {
                id = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title),
                fromWizard = 1
            });
        }

        /// <summary>
        /// Transform JobOpportunityPagingParameter into JobOpportunitySearchViewModel with Locations
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private JobOpportunitySearchViewModel GetSearchViewModel(JobOpportunityPagingParameter model)
        {
            var viewModel = new JobOpportunitySearchViewModel
            {
                SelectedLocationPlaceId = model.SelectedLocationPlaceId,
                SelectedLocationName = model.SelectedLocationName,
                JobCategory = model.JobCategory,
                Keyword = model.Keyword,
                IsRemote = model.IsRemote,
                CategoriesCount = _jobOpportunityService.GetMainJobCategoriesCount()
            };

            return viewModel;
        }

        public JobOpportunityController(
            IJobOpportunityService jobOpportunityService,
            ITwitterService twitterService)
        {
            _jobOpportunityService = jobOpportunityService;
            _twitterService = twitterService;
        }

        private readonly IJobOpportunityService _jobOpportunityService;
        private readonly ITwitterService _twitterService;
    }
}