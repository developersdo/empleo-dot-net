using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.Controllers
{
    public class JobOpportunityController : Controller
    {
        private readonly Database _databaseContext;

        public JobOpportunityController()
        {
            _databaseContext = new Database();
        }

        // GET: Vacantes
        public ActionResult Index()
        {
            var vmJobList = _databaseContext.JobOpportunities
                .OrderByDescending(e => e.PublishedDate)
                .ToList();

            if (!vmJobList.Any())
                return RedirectToAction("Index", "Home");

            return View(vmJobList);
        }

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
    }
}
