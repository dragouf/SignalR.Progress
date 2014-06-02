using System.Web;
using System.Web.Optimization;

namespace SignalRProgresss
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/libraries/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/libraries/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libraries/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/libraries/bootstrap.js",
                      "~/Scripts/libraries/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                      "~/Scripts/libraries/jquery.signalR-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                      "~/Scripts/libraries/knockout-{version}.js",
                      "~/Scripts/libraries/knockout.mapping-latest.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout-classes").Include(
                      "~/Scripts/Knockout/Models/*.js",
                      "~/Scripts/Knockout/Controllers/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
