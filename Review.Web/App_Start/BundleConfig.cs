using System.Web.Optimization;

namespace Review.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-select.min.js",
                "~/Scripts/moment-with-locales.min.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/bootstrap-tour.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/reviewList").Include(
                "~/Scripts/reviewList.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/fontawesome").Include("~/Content/font-awesome-4.7.0/css/font-awesome.css",
                "~/Content/font-awesome-4.7.0/css/font-awesome.min.css"));
        }
    }
}