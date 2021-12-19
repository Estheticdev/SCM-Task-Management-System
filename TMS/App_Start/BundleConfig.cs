using System.Web;
using System.Web.Optimization;

namespace AMS
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Note: ScreenCSS will be behind the views the application where it needed.
            bundles.Add(new StyleBundle("~/Content/ScreenCSS").Include(
                    "~/Content/ScreenCSS/common.css",
                    "~/Content/ScreenCSS/theme.css",
                    "~/Content/ScreenCSS/fileinput.css",
                    "~/Content/ScreenCSS/DateTimePicker.min.css",
                    "~/Content/ScreenCSS/dataTables.bootstrap4.min.css"));

            //Note: AplicationCSS will be used accross the application. It has been imported in _Layout.cshtml. 
            //You do not need to add it more anywhere.
            bundles.Add(new StyleBundle("~/Content/ApplicationCSS").Include(
                    "~/Content/ApplicationCSS/style.min.css",
                    "~/Content/ApplicationCSS/bootstrap-material-datetimepicker.css",
                    "~/Content/ApplicationCSS/dropify.min.css",
                    "~/Content/ApplicationCSS/animate.css",
                    "~/Content/ApplicationCSS/floating-label.css"));

            bundles.Add(new StyleBundle("~/Content/LoginCSS/css").Include(
                                        "~/Content/LoginCSS/bootstrap.css",
                                        "~/Content/LoginCSS/font-awesome.css",
                                        "~/Content/LoginCSS/lightcase.css",
                                        "~/Content/LoginCSS/style.css"));

            //Note: ScreenScripts will be behind the views the application where it needed.
            bundles.Add(new ScriptBundle("~/bundles/ScreenScripts").Include(
                    "~/Scripts/ScreenScripts/fileinput.min.js",
                    "~/Scripts/ScreenScripts/common.js",
                 //   "~/Scripts/ScreenScripts/theme.min.js",
                    "~/Scripts/ScreenScripts/jquery.mask.min.js",
                    "~/Scripts/ScreenScripts/DateTimePicker.min.js",
                    "~/Scripts/ScreenScripts/datepicker.en.js",
                    "~/Scripts/ScreenScripts/datatables.min.js"));

            //Note: AplicationScripts will be used accross the application. It has been imported in _Layout.cshtml. 
            //You do not need to add it more anywhere.
            bundles.Add(new ScriptBundle("~/bundles/ApplicationScripts").Include(
                    "~/Scripts/ApplicationScripts/jquery-3.2.1.min.js",
                    "~/Scripts/ApplicationScripts/popper.min.js",
                    "~/Scripts/ApplicationScripts/bootstrap.min.js",
                    "~/Scripts/ApplicationScripts/perfect-scrollbar.jquery.min.js",
                    "~/Scripts/ApplicationScripts/waves.js",
                    "~/Scripts/ApplicationScripts/sidebarmenu.js",
                    "~/Scripts/ApplicationScripts/sticky-kit.min.js",
                    "~/Scripts/ApplicationScripts/jquery.sparkline.min.js",
                    "~/Scripts/ApplicationScripts/custom.js",
                    "~/Scripts/ApplicationScripts/moment.js",
                    "~/Scripts/ApplicationScripts/moment-with-locales.js",
                    "~/Scripts/ApplicationScripts/bootstrap-material-datetimepicker.js",
                    "~/Scripts/ApplicationScripts/bootbox.min.js",
                   /// "~/Scripts/ApplicationScripts/notify.min.js",
                   "~/Scripts/ApplicationScripts/bootstrap-notify.js",
                   "~/Scripts/ApplicationScripts/bootstrap-notify.min",
                    "~/Scripts/ApplicationScripts/dropify.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/LoginScripts").Include(
                                       "~/Scripts/LoginScripts/bootstrap-3.1.1.min.js",
                                       "~/Scripts/LoginScripts/easing.js",
                                       "~/Scripts/LoginScripts/jquery-2.1.4.min.js",
                                       "~/Scripts/LoginScripts/jquery.events.touch.js",
                                       "~/Scripts/LoginScripts/jquery.flexisel.js",
                                       "~/Scripts/LoginScripts/lightcase.js",
                                       "~/Scripts/LoginScripts/move-top.js",
                                       "~/Scripts/LoginScripts/numscroller-1.0.js",
                                       "~/Scripts/LoginScripts/responsiveslides.min.js",
                                       "~/Scripts/LoginScripts/SmoothScroll.min.js"));
        }
    }
}
