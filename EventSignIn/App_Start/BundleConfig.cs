using System.Web;
using System.Web.Optimization;

namespace EventSignIn
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                            .Include(
                                "~/Scripts/jquery-{version}.js",
                                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/site")
                            .Include(
                                "~/Scripts/behaviors.js",
                                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                            .Include(
                                "~/Content/site.less",
                                "~/Content/less/bootstrap.less"));

            //bundles.Add(new ScriptBundle("~/bundles/plugins")
            //                .Include(
            //                    "~/Scripts/plugins/bootstrap-datetimepicker.min.js"));

            //bundles.Add(new StyleBundle("~/Content/css/plugins")
            //                .Include(
            //                    "~/Content/plugins/bootstrap-datetimepicker.min.css"));
        }
    }
}