
using System.Web;
using System.Web.Optimization;

                namespace SAS.v1
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/CustomJqueryBundle").Include(

                           "~/Scripts/jquery-{version}.js",
                           "~/Scripts/jquery-ui-{version}.js",
                           "~/Scripts/jquery.unobtrusive*",
                           "~/Scripts/jquery.validate"));

            bundles.Add(new ScriptBundle("~/bundles/CustomJqueryDataTable_Scripts").Include(

                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.responsive.js",
                        "~/Content/DataTables/css/dataTables.bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/CustomJqueryDataTable_Styles").Include(

                        "~/Content/DataTables/css/jquery.dataTables.css",
                        "~/Content/DataTables/css/responsive.dataTables.css",
                       "~/Content/DataTables/css/dataTables.bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                       "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"));

             }

        }
}