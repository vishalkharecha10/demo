using System.Web;
using System.Web.Optimization;

namespace FullCalender
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new GZipScriptBundle("~/bundles/layoutjs", new JsMinify()).Include(
                      "~/Scripts/js/jquery.js",
                      "~/Scripts/jquery.slimscroll.js",
                      "~/Scripts/umd/popper.min.js",
                      "~/Scripts/js/bootstrap.min.js",
                      "~/Scripts/js/custom-file-upload.js",
                      "~/Scripts/js/bootstrap-select.min.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/js/bootstrap-datetimepicker.min.js",
                       "~/Scripts/js/general.js",
                      "~/Scripts/jquery.form.js",
                      "~/Scripts/custom.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/loading-overlay.js"
                      ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/Site.css",
                        "~/Content/bootstrap.css",
                        "~/Content/fullcalendar.min.css"
                      ));

            bundles.Add(new GZipStyleBundle("~/Content/cssBundle", new CssMinify()).Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap-select.min.css",
                      "~/Content/css/bootstrap-datetimepicker.min.css",
                      "~/Content/css/style.css",
                       "~/Content/css/dataTables.bootstrap.min.css",
                      "~/Content/css/dev-style.css",
                       "~/Content/toastr.css",
                       "~/Content/font-awesome.min.css"
                     ));
        }
    }
}
