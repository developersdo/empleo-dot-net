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
                return View("Index");

            var context = new Database();
            var vm = context.JobOpportunities
                        .FirstOrDefault(d => d.Id == id);

            return vm == null 
                ? View("Index") 
                : View("Detail", vm);
        }
    }
}