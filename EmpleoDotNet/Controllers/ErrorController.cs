using System.Net;
using System.Web.Mvc;
using EmpleoDotNet.ViewModel;

namespace EmpleoDotNet.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// HTTP ERROR 400 (BAD REQUEST)
        /// </summary>
        public ActionResult Http400()
        {
            var viewModel = new ErrorViewModel
            {
                HttpStatusCode = HttpStatusCode.BadRequest,
                Title = "Lo siento, no encontré lo que buscabas.",
                SubTitle = "No te preocupes, estaremos arreglandolo en breve.",
            };

            return View("Index", viewModel);
        }

        /// <summary>
        /// HTTP ERROR 403 (FORBIDDEN)
        /// </summary>
        public ActionResult Http403()
        {
            var viewModel = new ErrorViewModel
            {
                HttpStatusCode = HttpStatusCode.Forbidden,
                Title = "Lo siento, no tienes permisos para ver esto.",
                SubTitle = "Si sigues intentando tendré que tomar cartas en el asunto.",
            };

            return View("Index", viewModel);
        }

        /// <summary>
        /// HTTP ERROR 404 (NOT FOUND)
        /// </summary>
        public ActionResult Http404()
        {
            var viewModel = new ErrorViewModel
            {
                HttpStatusCode = HttpStatusCode.NotFound,
                Title = "Lo siento, no encontré lo que buscabas.",
                SubTitle = "Descuida, No eres la única persona a quien esto le ha sucedido.",
            };

            return View("Index", viewModel);
        }

        /// <summary>
        /// HTTP ERROR 500 (INTERNAL SERVER ERROR)
        /// </summary>
        public ActionResult Http500()
        {
            var viewModel = new ErrorViewModel
            {
                HttpStatusCode = HttpStatusCode.InternalServerError,
                Title = "Oops! Ha ocurrido un error en nuestro sistema",
                SubTitle = "Estaré revisandolo en breve y empleando mi fuerza para arreglarlo. <br/>Gracias por tu paciencia.",
            };

            return View("Index", viewModel);
        }
    }
}