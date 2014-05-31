using System;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Models;

namespace EmpleoDotNet.Controllers
{
    public class JobOpportunityController : Controller
    {
        // GET: Vacantes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var context = new Database();
            var vm = context.JobOpportunities
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