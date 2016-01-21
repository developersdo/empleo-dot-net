using System.Web.Mvc;

namespace EmpleoDotNet.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// HTTP ERROR 400 (BAD REQUEST)
        /// </summary>
        /// <returns></returns>
        public ActionResult Http400()
        {
            return View();
        }

        /// <summary>
        /// HTTP ERROR 403 (FORBIDDEN)
        /// </summary>
        /// <returns></returns>
        public ActionResult Http403()
        {
            return View();
        }

        /// <summary>
        /// HTTP ERROR 404 (NOT FOUND)
        /// </summary>
        /// <returns></returns>
        public ActionResult Http404()
        {
            return View();
        }

        /// <summary>
        /// HTTP ERROR 500 (INTERNAL SERVER ERROR)
        /// </summary>
        /// <returns></returns>
        public ActionResult Http500()
        {
            return View();
        }
    }
}