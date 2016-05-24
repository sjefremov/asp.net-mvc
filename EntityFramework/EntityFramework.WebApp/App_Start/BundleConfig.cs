using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EntityFramework.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/customers")
                                .Include("~/Scripts/jquery-{version}.js")
                                .Include("~/Scripts/jquery-ui-{version}.js")
                                .Include("~/Scripts/jquery.unobtrusive*")
                                .Include("~/Scripts/jquery.validate*")
                                .Include("~/Scripts/bootstrap.js")
                                .Include("~/Scripts/customers.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                                .Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                        .Include("~/Scripts/jquery.unobtrusive*")
                        .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                                .Include("~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
        }
    }
}