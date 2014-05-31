using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Models;
using Microsoft.Owin.Security.Provider;

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

            return View(vmJobList.ToList());
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                return View("Index");

            var vm = _databaseContext.JobOpportunities
                        .FirstOrDefault(d => d.Id == id);

            return vm == null 
                ? View("Index") 
                : View("Detail", vm);
        }
    }
}