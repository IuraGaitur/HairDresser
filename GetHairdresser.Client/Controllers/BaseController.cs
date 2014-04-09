using GetHairdresser.Client.FormsAuth;
using GetHairdresser.Client.UserService;
using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetHairdresser.Client.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IAuthentificationService _AuthenticationService;


        public BaseController()
        {
            _AuthenticationService = DependencyResolver.Current.GetService<IAuthentificationService>();
        }

        public string CurrentUser
        {
            get
            {
                return _AuthenticationService.CurrentUser;
            }
        }

        protected bool IsAuthenticated
        {
            get { return CurrentUser != null; }
        }

    }
}
