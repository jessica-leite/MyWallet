using System.Web;
using System.Web.Optimization;

namespace MyWallet.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/vendor/fontawesome-free/css/all.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/css/sb-admin-2.min.css",
                     "~/css/bootstrap-datepicker3.min.css"));

            bundles.Add(new StyleBundle("~/Content/MyWallet").Include(
                     "~/Content/MyWallet.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-bootstrap").Include(
                "~/vendor/jquery/jquery.min.js",
                "~/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/vendor/jquery-easing/jquery.easing.min.js",
                "~/js/sb-admin-2.min.js",
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/bootstrap-datepicker.pt.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-val").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/moment.min.js"));
        }
    }
}
