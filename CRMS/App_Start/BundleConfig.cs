using System.Web;
using System.Web.Optimization;

namespace CRMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new StyleBundle("~/Content/jqueryui")
               .Include("~/Content/themes/base/all.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datePicker").Include(
                    "~/Scripts/datepicker.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/formValidator").Include(
                    "~/Scripts/jquery.validate.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/alphanumeric").Include(
                    "~/Scripts/alphanumeric.js"
                )); 
            
            bundles.Add(new ScriptBundle("~/bundles/additionalMethods").Include(
                    "~/Scripts/additional-methods.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/datePickerEnglish").Include(
                    "~/Scripts/datepicker.en.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/fontAwesome").Include(
                        "~/Content/font-awesome-4.7.0/css/font-awesome.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/datePicker").Include(
                    "~/Content/datepicker.css"
                ));
        }
    }
}
