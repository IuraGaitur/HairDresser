using GetHairdresser.Client.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GetHairdresser.Client
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            ViewEngines.Engines.Add(new CustomViewEngine());//View engine like Razor,Aspx//Create HTML from Views
            AreaRegistration.RegisterAllAreas();//for roots //Route config
            WebApiConfig.Register(GlobalConfiguration.Configuration);//register web api file
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//filter applied to controllers and actions
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);//register css and js in order to be minified and bundled
            AuthConfig.RegisterAuth();//register external auth
        }
    }
}