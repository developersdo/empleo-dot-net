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
using System;

namespace EmpleoDotNet.Controllers
{
    public class JobOpportunityController : EmpleoDotNetController
    {
        public ActionResult Index(JobOpportunityPagingParameter model)
        {
            var viewModel = GetSearchViewModel(model);

            if (!string.IsNullOrWhiteSpace(viewModel.SelectedLocationName) &&
                string.IsNullOrWhiteSpace(viewModel.SelectedLocationPlaceId))
            {
                ModelState.AddModelError("SelectedLocationName", "");
                return View(viewModel).WithError("Debe seleccionar una Localidad para buscar.");
            }

            var jobOpportunities = _jobOpportunityService.GetAllJobOpportunitiesPagedByFilters(model);

            viewModel.Result = jobOpportunities;

            return View(viewModel);
        }

        // GET: /JobOpportunity/Detail/4-jobtitle
        public ActionResult Detail(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction(nameof(Index));

            var value = GetIdFromTitle(id);
            if (value == 0)
                return RedirectToAction(nameof(Index));

            var viewModel = _jobOpportunityService.GetJobOpportunityById(value);

            if (viewModel == null)
                return View(nameof(Index))
                    .WithError("La vacante solicitada no existe. Por favor escoge una vacante válida del listado");

            var expectedUrl = UrlHelperExtensions.SeoUrl(value, viewModel.Title.SanitizeUrl());

            if (!expectedUrl.Equals(id, StringComparison.OrdinalIgnoreCase))
                return RedirectToActionPermanent(nameof(Detail), new { id = expectedUrl });

            ViewBag.RelatedJobs =
                _jobOpportunityService.GetCompanyRelatedJobs(value, viewModel.CompanyName);

            var cookieView = $"JobView{viewModel.Id}";
            if (!CookieHelper.Exists(cookieView))
            {
                _jobOpportunityService.UpdateViewCount(viewModel.Id);
                CookieHelper.Set(cookieView, viewModel.Id.ToString());
            }

            return View(nameof(Detail), viewModel);
        }

        [HttpGet]
        public ActionResult New()
        {
            var viewModel = new NewJobOpportunityViewModel();

            return View(viewModel)
                .WithInfo("Prueba nuestro nuevo proceso guiado de creación de posiciones haciendo <b><a href='" + Url.Action("Wizard") + "'>click aquí</a></b>");
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

            if (string.IsNullOrWhiteSpace(model.LocationPlaceId))
            {
                ModelState.AddModelError(nameof(model.LocationName), "");
                return View(model).WithError("Debe seleccionar una Localidad.");
            }

            var jobOpportunity = model.ToEntity();

            _jobOpportunityService.CreateNewJobOpportunity(jobOpportunity);

            await _twitterService.PostNewJobOpportunity(jobOpportunity).ConfigureAwait(false);

            return RedirectToAction(nameof(Detail), new {
                id = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title)
            });
        }

        [HttpGet]
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

            return RedirectToAction(nameof(Detail), new {
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
            if (string.IsNullOrWhiteSpace(model.SelectedLocationName))
            {
                model.SelectedLocationLatitude = string.Empty;
                model.SelectedLocationLongitude = string.Empty;
                model.SelectedLocationPlaceId = string.Empty;
            }

            var viewModel = new JobOpportunitySearchViewModel {
                SelectedLocationPlaceId = model.SelectedLocationPlaceId,
                SelectedLocationName = model.SelectedLocationName,
                SelectedLocationLongitude = model.SelectedLocationLongitude,
                SelectedLocationLatitude = model.SelectedLocationLatitude,
                JobCategory = model.JobCategory,
                Keyword = model.Keyword,
                IsRemote = model.IsRemote,
                CategoriesCount = _jobOpportunityService.GetMainJobCategoriesCount(),
            };

            return viewModel;
        }

        private static int GetIdFromTitle(string title)
        {
            int id;
            var url = title.Split('-');

            if (string.IsNullOrEmpty(title) || url.Length == 0 || !int.TryParse(url[0], out id))
                return 0;

            return id;
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