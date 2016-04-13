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
using System.Security.Policy;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.ViewModel.JobOpportunityLike;
using System.Security.Policy;
using Microsoft.AspNet.Identity;
using Tweetinvi.Core.Extensions;

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

            var jobOpportunityId = GetIdFromTitle(id);

            if (jobOpportunityId == 0)
                return RedirectToAction(nameof(Index));

            var viewModel = _jobOpportunityService.GetJobOpportunityById(jobOpportunityId);

            if (viewModel == null)
                return View(nameof(Index))
                    .WithError("La vacante solicitada no existe. Por favor escoge una vacante válida del listado");

            var expectedUrl = UrlHelperExtensions.SeoUrl(jobOpportunityId, viewModel.Title.SanitizeUrl());

            if (!expectedUrl.Equals(id, StringComparison.OrdinalIgnoreCase))
                return RedirectToActionPermanent(nameof(Detail), new { id = expectedUrl });

            ViewBag.RelatedJobs =
                _jobOpportunityService.GetCompanyRelatedJobs(jobOpportunityId, viewModel.CompanyName);

            ViewBag.CanLike = !CookieHelper.Exists(GetLikeCookieName(jobOpportunityId));

            var cookieView = $"JobView{viewModel.Id}";
            if (!CookieHelper.Exists(cookieView))
            {
                _jobOpportunityService.UpdateViewCount(viewModel.Id);
                CookieHelper.Set(cookieView, viewModel.Id.ToString());
            }

            return View(nameof(Detail), viewModel);
        }

        [HttpGet]

        [Authorize]
        public ActionResult New()
        {
            var viewModel = new NewJobOpportunityViewModel();

            return View(viewModel)
                .WithInfo("Prueba nuestro nuevo proceso guiado de creación de posiciones haciendo <b><a href='" + Url.Action("Wizard") + "'>click aquí</a></b>");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [CaptchaValidator(RequiredMessage = "Por favor confirma que no eres un robot")]
        [Authorize]
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

            if (!UrlHelperExtensions.IsImageAvailable(model.CompanyLogoUrl))
            {
                return View(model).WithError("La url del logo debe ser a una imagen en formato png o jpg");
            }

            var jobOpportunity = model.ToEntity();
            var userId = User.Identity.GetUserId();

            _jobOpportunityService.CreateNewJobOpportunity(jobOpportunity, userId);

            await _twitterService.PostNewJobOpportunity(jobOpportunity,Url).ConfigureAwait(false);

            return RedirectToAction(nameof(Detail), new {
                id = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title)
            });
        }

        [HttpGet]
        public ActionResult Wizard()
        {
            var viewModel = new Wizard();

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [CaptchaValidator(RequiredMessage = "Por favor confirma que no eres un robot", ErrorMessage = "El captcha es incorrecto.")]
        public async Task<ActionResult> Wizard(Wizard model)
        {
            if (!ModelState.IsValid)
                return View(model)
                    .WithError("Han ocurrido errores de validación que no permiten continuar el proceso");

            var jobOpportunity = model.ToEntity();

            _jobOpportunityService.CreateNewJobOpportunity(jobOpportunity, User.Identity.GetUserId());

            await _twitterService.PostNewJobOpportunity(jobOpportunity,Url);

            return RedirectToAction(nameof(Detail), new {
                id = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title),
                fromWizard = 1
            });
        }

        [HttpPost]
        public JsonResult Like(JobOpportunityLike model)
        {
            var cookieName = GetLikeCookieName(model.JobOpportunityId);
            
            if (CookieHelper.Exists(cookieName))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = true, message = "Ya has votado por este empleo." });
            }

            _jobOpportunityLikeService.CreateNewLike(model);

            CookieHelper.Set(cookieName, model.JobOpportunityId.ToString());

            var jobLikeData = _jobOpportunityLikeService.GetLikesByJobOpportunityId(model.JobOpportunityId);

            var jobOpportunityLikeData = new JobOpportunityLikeViewModel
            {
                Likes = jobLikeData.Count(x => x.Like),
                DisLikes = jobLikeData.Count(x => !x.Like)
            };
                
            return Json(new { error = false, data = jobOpportunityLikeData });
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

        private static string GetLikeCookieName(int jobOpportunityId)
        {
            return $"JobLike{jobOpportunityId}";
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
            ITwitterService twitterService, 
            IJobOpportunityLikeService jobOpportunityLikeService)
        {
            _jobOpportunityService = jobOpportunityService;
            _twitterService = twitterService;
            _jobOpportunityLikeService = jobOpportunityLikeService;
        }

        private readonly IJobOpportunityService _jobOpportunityService;
        private readonly ITwitterService _twitterService;
        private readonly IJobOpportunityLikeService _jobOpportunityLikeService;
    }
}