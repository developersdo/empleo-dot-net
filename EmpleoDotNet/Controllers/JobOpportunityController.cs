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
using System.Net;
using EmpleoDotNet.Core.Domain;
using Microsoft.AspNet.Identity;
using EmpleoDotNet.Services.Social.Slack;
using System.Configuration;
using EmpleoDotNet.ViewModel.Slack;
using System.Linq;
using Newtonsoft.Json;
using System.Configuration;

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

        // GET: /jobs/4-jobtitle
        public ActionResult Detail(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction(nameof(Index));

            var jobOpportunityId = GetIdFromTitle(id);

            if (jobOpportunityId == 0)
                return RedirectToAction(nameof(Index));

            var jobOpportunity = _jobOpportunityService.GetJobOpportunityById(jobOpportunityId);

            if (jobOpportunity == null)
                return View(nameof(Detail))
                    .WithError("La vacante solicitada no existe. Por favor escoge una vacante válida del listado");

            if (jobOpportunity.Approved == false)
                return View(nameof(Detail))
                    .WithSuccess("Esta vacante no ha sido aprobada todavia. Si la acaba de someter, por favor revise de nuevo más tarde. Nuestros moderadores estarán revisando su solicitud en breve." +
                    "Mientras tanto, puedes te sugerimos que contemples convertirte en un backer de nuestra plataforma. Más detalles en https://opencollective.com/emplea_do" +
                    "");

            var expectedUrl = UrlHelperExtensions.SeoUrl(jobOpportunityId, jobOpportunity.Title.SanitizeUrl());

            if (!expectedUrl.Equals(id, StringComparison.OrdinalIgnoreCase))
                return RedirectToActionPermanent(nameof(Detail), new { id = expectedUrl });

            ViewBag.RelatedJobs =
                _jobOpportunityService.GetCompanyRelatedJobs(jobOpportunityId, jobOpportunity.CompanyName);

            ViewBag.CanLike = !CookieHelper.Exists(GetLikeCookieName(jobOpportunityId));

            var cookieView = $"JobView{jobOpportunity.Id}";

            if (IsJobOpportunityOwner(id) || CookieHelper.Exists(cookieView))
            {
                return jobOpportunity.IsHidden
                    ? View(nameof(Detail), jobOpportunity).WithInfo(Constants.JobDetailWithInfoMessage)
                    : View(nameof(Detail), jobOpportunity);
            }

            _jobOpportunityService.UpdateViewCount(jobOpportunity.Id);
            CookieHelper.Set(cookieView, jobOpportunity.Id.ToString());

            return jobOpportunity.IsHidden
                ? View(nameof(Detail), jobOpportunity).WithInfo(Constants.JobDetailWithInfoMessage)
                : View(nameof(Detail), jobOpportunity);
        }

        [HttpGet]

        public ActionResult New()
        {
            return Redirect("https://beta.emplea.do");
            var viewModel = new NewJobOpportunityViewModel();
            viewModel.MapsApiKey = ConfigurationManager.AppSettings["GoogleMapsApiKey"];

            return View(viewModel)
                .WithWarning("Prueba nuestro nuevo proceso guiado de creación de posiciones haciendo <b><a href='" + Url.Action("Wizard") + "'>click aquí</a></b>");
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

            if (!string.IsNullOrWhiteSpace(model.CompanyLogoUrl) && UrlHelperExtensions.IsValidImageUrl(model.CompanyLogoUrl))
            {
                return View(model).WithError("La url del logo debe ser a una imagen en formato png o jpg");
            }

            var jobOpportunity = model.ToEntity();
            var userId = User.Identity.GetUserId();
            jobOpportunity.Approved = false;        // new jobs unapproved by default

            _jobOpportunityService.CreateNewJobOpportunity(jobOpportunity, userId);
            try
            {
                await _slackService.PostNewJobOpportunity(jobOpportunity, Url).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return RedirectToAction(nameof(Detail), new
            {
                id = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title)
            });
        }

        [HttpGet]
        public ActionResult Wizard()
        {
            return Redirect("https://beta.emplea.do");
            var viewModel = new Wizard();
            viewModel.MapsApiKey = ConfigurationManager.AppSettings["GoogleMapsApiKey"];
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(string title)
        {
            var job = GetJobOpportunityFromTitle(title);

            if (!IsJobOpportunityOwner(title))
                return RedirectToAction("Detail", new { id = title });

            var wizardvm = ViewModel.JobOpportunity.Wizard.FromEntity(job);
            return View("Wizard", wizardvm);
        }

        [Authorize]
        public ActionResult Delete(string title, bool returnPrevious = true)
        {
            var jobOpportunity = GetJobOpportunityFromTitle(title);
            if (IsJobOpportunityOwner(title))
            {
                _jobOpportunityService.SoftDeleteJobOpportunity(jobOpportunity);
            }

            if (Request.UrlReferrer == null || returnPrevious == false)
            {
                return RedirectToAction("Index", "Home")
                        .WithSuccess($"Se ha borrado exitosamente la oportunidad de empleo: {jobOpportunity.Title}");
            }

            return Redirect(Request.UrlReferrer.ToString())
                        .WithSuccess($"Se ha borrado exitosamente la oportunidad de empleo: {jobOpportunity.Title}");
        }

        [HttpPost]
        public JsonResult ToggleHide(string title)
        {
            var jobOpportunity = GetJobOpportunityFromTitle(title);
            if (IsJobOpportunityOwner(title))
            {
                _jobOpportunityService.ToggleHideState(jobOpportunity);
            }

            return Json(new { isHidden = jobOpportunity.IsHidden });

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
            var jobExists = _jobOpportunityService.JobExists(model.Id);

            if (!jobExists)
            {
                jobOpportunity.Approved = false;        // new jobs unapproved by default
                _jobOpportunityService.CreateNewJobOpportunity(jobOpportunity, User.Identity.GetUserId());
            }
            else
            {
                _jobOpportunityService.UpdateJobOpportunity(model.Id, model.ToEntity());
            }

            try
            {
                await _slackService.PostNewJobOpportunity(jobOpportunity, Url);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return RedirectToAction(nameof(Detail), new
            {
                id = UrlHelperExtensions.SeoUrl(jobOpportunity.Id, jobOpportunity.Title),
                fromWizard = 1
            });
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public JsonResult Like(int jobOpportunityId, bool like)
        {
            var cookieName = GetLikeCookieName(jobOpportunityId);
            
            if (CookieHelper.Exists(cookieName))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { error = true, message = "Ya has votado por este empleo." });
            }
                     
            _jobOpportunityService.CreateNewReaction(jobOpportunityId, like);

            CookieHelper.Set(cookieName, jobOpportunityId.ToString());

            var jobOpportunity = _jobOpportunityService.GetJobOpportunityById(jobOpportunityId);
            return jobOpportunity == null 
                ? Json(new { error = true, message = "No se encuentra empleo con el id indicado" }) 
                : Json(new { error = false, data = new 
                {
                    jobOpportunity.Likes,
                    jobOpportunity.DisLikes
                }});
        }

        /// <summary>
        /// Validates the payload response that comes from the Slack interactive message actions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public async Task Validate()
        {
            var payload = JsonConvert.DeserializeObject<PayloadResponseDto>(Request["payload"]);
            int jobOpportunityId = Convert.ToInt32(payload.callback_id);
            var jobOpportunity = _jobOpportunityService.GetJobOpportunityById(jobOpportunityId);
            var isJobApproved = payload.actions.FirstOrDefault()?.value == "approve";
            var isJobRejected = payload.actions.FirstOrDefault()?.value == "reject";
            var isTokenValid = payload.token == ConfigurationManager.AppSettings["slackVerificationToken"];

            try
            {
                if (isTokenValid && isJobApproved)
                {
                    jobOpportunity.Approved = true;
                    _jobOpportunityService.UpdateJobOpportunity(jobOpportunityId, jobOpportunity);
                    await _slackService
                        .PostJobOpportunityResponse(jobOpportunity, Url, payload.response_url, payload?.user?.id, true);
                    await _twitterService
                        .PostNewJobOpportunity(jobOpportunity, Url).ConfigureAwait(false);
                }
                else if (isTokenValid && isJobRejected)
                {
                    // Jobs are rejected by default, so there's no need to update the DB
                    if (jobOpportunity == null)
                    {
                        await _slackService.PostJobOpportunityErrorResponse(jobOpportunity, Url, payload.response_url);
                    } 
                    else
                    {
                        await _slackService.PostJobOpportunityResponse(jobOpportunity, Url, payload.response_url, payload?.user?.id, false);
                    }
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                //Catches exceptions so that the raw HTML doesn't appear on the slack channel
                await _slackService.PostJobOpportunityErrorResponse(jobOpportunity, Url, payload.response_url);
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
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

            var viewModel = new JobOpportunitySearchViewModel
            {
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

        private JobOpportunity GetJobOpportunityFromTitle(string title)
        {
            var jobId = GetIdFromTitle(title);
            return _jobOpportunityService.GetJobOpportunityById(jobId);
        }

        private bool IsJobOpportunityOwner(string title)
        {
            var jobOpportunity = GetJobOpportunityFromTitle(title);
            var currentUser = User.Identity.GetUserId();
            return (currentUser != null && jobOpportunity.UserProfile?.UserId == currentUser);
        }

        public JobOpportunityController(
            IJobOpportunityService jobOpportunityService,
            ISlackService slackService,
            ITwitterService twitterService)
        {
            _jobOpportunityService = jobOpportunityService;
            _slackService = slackService;
            _twitterService = twitterService;
        }

        private readonly IJobOpportunityService _jobOpportunityService;
        private readonly ITwitterService _twitterService;
        private readonly ISlackService _slackService;
    }
}