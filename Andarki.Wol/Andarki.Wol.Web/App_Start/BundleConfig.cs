using System.Web;
using System.Web.Optimization;

namespace Andarki.Wol.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                            "~/lib/angular/angular.js",
                            "~/lib/angular/angular-resource.js",
                            "~/lib/angular-ui-bootstrap/ui-bootstrap-0.4.0.js",
                            "~/lib/angular-ui-bootstrap/ui-bootstrap-tpls-0.4.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/wol").Include(
                     "~/js/app.js",
                     "~/js/controllers.js",
                     "~/js/directives.js",
                     "~/js/filters.js",
                     "~/js/services.js"));
        }
    }
}