using System.Net;
using System.Web.Mvc;
using EmpleoDotNet.Controllers;
using EmpleoDotNet.ViewModel;
using FluentAssertions;
using NUnit.Framework;

namespace EmpleoDotNet.Tests.Web.Controllers
{
    [TestFixture]
    public class ErrorControllerTest
    {
        private ErrorController _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ErrorController();
        }

        [Test]
        public void Http400()
        {
            var result = _sut.Http400();

            VerifyResult(
                result: result,
                statusCode: HttpStatusCode.BadRequest,
                title: "Lo siento, no encontré lo que buscabas.",
                subtitle: "No te preocupes, estaremos arreglandolo en breve."
                );
        }

        [Test]
        public void Http403()
        {
            var result = _sut.Http403();

            VerifyResult(
                result: result,
                statusCode: HttpStatusCode.Forbidden,
                title: "Lo siento, no tienes permisos para ver esto.",
                subtitle: "Si sigues intentando tendré que tomar cartas en el asunto."
                );
        }

        [Test]
        public void Http404()
        {
            var result = _sut.Http404();

            VerifyResult(
                result: result,
                statusCode: HttpStatusCode.NotFound,
                title: "Lo siento, no encontré lo que buscabas.",
                subtitle: "Descuida, No eres la única persona a quien esto le ha sucedido."
                );
        }

        [Test]
        public void Http500()
        {
            var result = _sut.Http500();

            VerifyResult(
                result: result,
                statusCode: HttpStatusCode.InternalServerError,
                title: "Oops! Ha ocurrido un error en nuestro sistema",
                subtitle: "Estaré revisandolo en breve y empleando mi fuerza para arreglarlo. <br/>Gracias por tu paciencia."
                );
        }

        private void VerifyResult(
            ActionResult result,
            HttpStatusCode statusCode,
            string title,
            string subtitle
            )
        {
            var viewResult = (ViewResult)result;
            var model = (ErrorViewModel)viewResult.Model;

            viewResult.ViewName.Should().Be("Index");
            model.HttpStatusCode.Should().Be(statusCode);
            model.Title.Should().Be(title);
            model.SubTitle.Should().Be(subtitle);
        }
    }
}
