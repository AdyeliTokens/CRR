﻿using System.Web;
using System.Web.Optimization;

namespace CRR
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Style/Bootstrap").Include("~/bower_components/bootstrap/dist/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Style/Font-Awesome").Include("~/bower_components/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/Style/AdminLTE").Include(
                "~/bower_components/admin-lte/css/AdminLTE.css",
                "~/bower_components/admin-lte/css/skins/_all-skins.min.css",
                "~/plugins/iCheck/flat/blue.css"));
            
            bundles.Add(new StyleBundle("~/Style/DataTables").Include("~/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Style/DataRangePicker").Include("~/bower_components/bootstrap-daterangepicker/daterangepicker.css"));
            bundles.Add(new StyleBundle("~/Style/DataPicker").Include("~/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"));
            bundles.Add(new StyleBundle("~/Style/select2").Include("~/bower_components/select2/dist/css/select2.min.css"));
            bundles.Add(new StyleBundle("~/Style/ColorPicker").Include("~/bower_components/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css"));
            bundles.Add(new StyleBundle("~/Style/Vendor/Bootstrap").Include("~/vendor/bootstrap/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Style/Vendor/Font-Awesome").Include("~/vendor/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/Style/Vendor/SimpleLineIcons").Include("~/vendor/simple-line-icons/css/simple-line-icons.css"));
            bundles.Add(new StyleBundle("~/Style/Vendor/DeviceMockups").Include("~/device-mockups/device-mockups.min.css"));
            bundles.Add(new StyleBundle("~/Style/Vendor/NewAge").Include("~/css/new-age.css"));
            bundles.Add(new StyleBundle("~/Style/Vendor/NewAge").Include("~/css/new-age.css"));
            bundles.Add(new StyleBundle("~/Style/Vendor/NewAge").Include("~/css/new-age.css"));
            bundles.Add(new StyleBundle("~/Style/Select2").Include("~/bower_components/select2/dist/css/select2.min.css"));
            bundles.Add(new StyleBundle("~/Content/cssVectorMap").Include("~/plugins/jvectormap/jquery-jvectormap-1.2.2.css"));
             #endregion

            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/JS/jquery").Include("~/bower_components/jquery/dist/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/JS/Complements").Include(
                "~/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/bower_components/fastclick/lib/fastclick.js",
                 "~/plugins/iCheck/icheck.min.js"));
            bundles.Add(new ScriptBundle("~/JS/AdminLTE").Include("~/dist/js/adminlte.min.js"));
            bundles.Add(new ScriptBundle("~/JS/Demo").Include("~/bower_components/dist/js/demo.js"));
            bundles.Add(new ScriptBundle("~/JS/Moment").Include("~/bower_components/moment/moment.js"));
            bundles.Add(new ScriptBundle("~/JS/select2").Include("~/bower_components/select2/dist/js/select2.full.min.js"));

            bundles.Add(new ScriptBundle("~/JS/Vendor/JQuery").Include("~/vendor/jquery/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/JS/Vendor/Popper").Include("~/vendor/popper/popper.min.js")); 
            bundles.Add(new ScriptBundle("~/JS/Vendor/JQueryEasing").Include("~/vendor/jquery-easing/jquery.easing.min.js"));
            bundles.Add(new ScriptBundle("~/JS/Vendor/NewAge").Include("~/js/new-age.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/JS/Select2").Include("~/bower_components/select2/dist/js/select2.full.min.js"));
            bundles.Add(new ScriptBundle("~/JS/ChartJS").Include("~/bower_components/chart.js/Chart.js"));
            bundles.Add(new ScriptBundle("~/JS/Sparkline").Include("~/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js"));
            bundles.Add(new ScriptBundle("~/JS/SlimScroll").Include("~/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"));
            bundles.Add(new ScriptBundle("~/JS/Evento").Include("~/js/Evento.js"));
            bundles.Add(new ScriptBundle("~/JS/DetailsEvento").Include("~/js/DetailsEvento.js"));

            bundles.Add(new ScriptBundle("~/JS/Bootstrap").Include("~/bower_components/bootstrap/dist/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/JS/Vendor/Bootstrap").Include("~/vendor/bootstrap/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/JS/DataTables").Include("~/bower_components/datatables.net/js/jquery.dataTables.min.js",
                "~/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/JS/DataPicker").Include(
                 "~/bower_components/moment/min/moment.min.js",
                 "~/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                 "~/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                 "~/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
                 "~/plugins/timepicker/bootstrap-timepicker.min.js"));

            bundles.Add(new ScriptBundle("~/JS/DataRangePicker").Include(
                "~/bower_components/moment/min/moment.min.js",
                "~/bower_components/bootstrap-daterangepicker/daterangepicker.js"));

            bundles.Add(new ScriptBundle("~/JS/ColorPicker").Include("~/bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/JS/datepick").Include("~/bower_components/js/datepick.js"));
            bundles.Add(new ScriptBundle("~/JS/Chart.2.3.0").Include("~/bower_components/js/Chart.2.3.0.min.js"));
            #endregion
        }
    }

}
