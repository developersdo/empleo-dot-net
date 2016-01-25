using System.Net;

namespace EmpleoDotNet.ViewModel
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
            ImageUrl = "~/Content/img/pinedax.png";
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}