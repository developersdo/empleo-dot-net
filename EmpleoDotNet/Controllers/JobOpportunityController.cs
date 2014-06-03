using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Models;
using EmpleoDotNet.ViewModel;

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
        public ActionResult Index()
        {
            var vmJobList = _databaseContext.JobOpportunities
                .OrderByDescending(e => e.PublishedDate)
                .ToList();

            if (!vmJobList.Any())
                return RedirectToAction("Index", "Home");

            return View(vmJobList);
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
