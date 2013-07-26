using System.Web;
using System.Web.Optimization;

namespace Andarki.Wol.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/lib/angular/angular.js",
                        "~/lib/angular/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/wol").Include(
                 "~/js/app.js",
                 "~/js/controllers.js",
                 "~/js/directives.js",
                 "~/js/filters.js",
                 "~/js/services.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            //bundles.Add(new ScriptBundle("~/bundles/test").Include("~/Scripts/Archive/jquery-1.8.2.js"));
        }
    }
}