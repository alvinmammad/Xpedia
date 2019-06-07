using System.Web;
using System.Web.Optimization;

namespace Xpedia
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/xpedia").Include(
                "~/UI/js/jquery-3.3.1.min.js",
                "~/UI/js/bootstrap.min.js",
                 "~/UI/js/owl.carousel.js",
                "~/UI/js/modernizr.js",
                "~/UI/js/jquery.menu-aim.js",
                "~/UI/js/jquery-ui.js",
                "~/UI/js/own-menu.js",
                "~/UI/js/jquery.bxslider.min.js",
                "~/UI/js/jquery.magnific-popup.js",
                "~/UI/js/my.js",
                "~/UI/js/xpedia.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/xpedia").Include(
            //    "~/UI/css/custom.css",
            //    "~/UI/css/xpedia.css"
            //    ));

            bundles.Add(new StyleBundle("~/UI/css").Include(
                "~/UI/css/animate.css",
                "~/UI/css/fonts.css",
                "~/UI/css/flaticon.css",
                 "~/UI/css/font-awesome.css",
                "~/UI/css/owl.carousel.css",
                "~/UI/css/owl.theme.default.css",
                "~/UI/css/magnific-popup.css",
                "~/UI/css/reset.css",
                "~/UI/css/style.css",
                "~/UI/css/responsive.css",
                "~/UI/css/bootstrap.min.css"
               
                )/*.Include("~/UI/css/font-awesome.css",new CssRewriteUrlTransform()*/);


            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            BundleTable.EnableOptimizations = true;
        }

    }
}
