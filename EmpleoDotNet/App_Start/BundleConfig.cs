using System.Web.Optimization;

namespace EmpleoDotNet
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //Select2 Bundles
            bundles.Add(new ScriptBundle("~/bundles/select2Script").Include("~/Scripts/select2.js"));
            bundles.Add(new StyleBundle("~/bundles/select2Style").Include("~/Content/css/select2.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/jobOpportunity/Likes.js",
                        "~/Scripts/app.js"
                        ));

            RegisterTemplate(bundles);
        }

        private static void RegisterTemplate(BundleCollection bundles)
        {
            RegisterTemplateStyles(bundles);
            RegisterTemplateScripst(bundles);
        }

        private static void RegisterTemplateScripst(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/theme/js").Include("~/Scripts/theme/*.js",
                "~/Scripts/theme/waypoints.min.js",
                "~/Scripts/theme/scrollReveal.min.js",
                "~/Scripts/theme/retina.min.js",
                "~/Scripts/theme/owl.carousel.min.js",
                "~/Scripts/theme/jquery.nouislider.all.min.js",
                "~/Scripts/theme/jquery.counterup.min.js",
                "~/Scripts/theme/jquery.ba-cond.min.js",
                "~/Scripts/theme/bootstrap3-wysihtml5.all.min.js",
                "~/Scripts/theme/instafedd.min.js",
                "~/Scripts/theme/jflickrfeed.min.js",
                "~/Scripts/sweetalert2.js",
                "~/Scripts/icheck.min.js"));
        }

        private static void RegisterTemplateStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/theme/css")
                .Include("~/Content/css/theme/jquery.flexmenu.css",
                "~/Content/css/theme/owl.carousel.css",
                "~/Content/css/theme/animate.css",
                "~/Content/css/theme/jquery.fancybox.css", 
                "~/Content/css/theme/jquery.nouislider.css",
                "~/Content/css/theme/style.css",
                "~/Content/sweetalert2.css",
                "~/Content/flat/green.css"));
        }
    }
}
