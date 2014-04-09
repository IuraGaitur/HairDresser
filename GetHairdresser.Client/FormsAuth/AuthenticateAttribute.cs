using GetHairdresser.Client.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetHairdresser.Client.FormsAuth
{
    public class AuthenticateAttribute:AuthorizeAttribute
    {
        //public bool AllowAnonim { get; set; }
        //public UserRoles AccessTole { get; set; }
        //public AuthenticateAttribute()
        //{

        //}

        //public AuthenticateAttribute(bool allowAnonim)
        //{
        //    this.AllowAnonim = allowAnonim;
        //}
        //public AuthenticateAttribute(UserRoles accessRole)
        //{
        //    AccessTole = accessRole;
        //}

        //protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        //{
        //    if (AllowAnonim)
        //        return true;


        //    User user = DependencyResolver.Current.GetService<IAuthentificationService>().CurrentUser;
        //    if (user == null)
        //        return false;

        //    if (AccessTole == 0)
        //        return true;

        //    return user.IsInRole(AccessTole);
        //}

        //protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        //{
        //    filterContext.Result = new System.Web.Mvc.RedirectResult("/login", false);
        //}
    }
}