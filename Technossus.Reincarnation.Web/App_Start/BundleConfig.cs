using System.Web.Optimization;

namespace Technossus.Reincarnation.Web
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/require.js").Include(
                    "~/Scripts/require.js"));
            bundles.Add(new ScriptBundle("~/bundles/text.js").Include(
                     "~/Scripts/text.js"));
            bundles.Add(new ScriptBundle("~/bundles/knockoutjs").Include(
                     "~/Scripts/knockout-3.4.2.js"));
            bundles.Add(new ScriptBundle("~/bundles/knockout.mapping-latest.js").Include(
          "~/Scripts/knockout.mapping-latest.js"));
            bundles.Add(new ScriptBundle("~/bundles/knockout.mapping-latest.debug.js").Include(
          "~/Scripts/knockout.mapping-latest.debug.js"));
            bundles.Add(new ScriptBundle("~/bundles/require.config.js").Include(
          "~/Configurations/require.config.js"));
            bundles.Add(new ScriptBundle("~/bundles/ko.components.js").Include(
                  "~/Components/Shared/shared.components.js",
                     "~/Components/App/app.components.js"));
        }
    }
}
