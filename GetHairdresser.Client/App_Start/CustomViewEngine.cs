using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetHairdresser.Client.App_Start
{
    public class CustomViewEngine:WebFormViewEngine
    {
        public CustomViewEngine()
        {
            var viewLocations = new[] {  
            "~/Views/{1}/{0}.aspx",  
            "~/Views/{1}/{0}.ascx",  
            "~/Views/Shared/{0}.aspx",  
            "~/Views/Shared/{0}.ascx",  
            "~/Views/Client/{0}.aspx",  
            "~/Views/Client/{0}.ascx",
            "~/Views/Client/{0}.cshtml",
            "~/Views/Hairdress/{0}.aspx",  
            "~/Views/Hairdress/{0}.ascx",
            "~/Views/Hairdress/{0}.cshtml"
            
        };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }
    }
}