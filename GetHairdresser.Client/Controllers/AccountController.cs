using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using GetHairdresser.Client.Filters;
using GetHairdresser.Client.Models;
using System.Web.Script.Serialization;
using GetHairDresser.Common;
using AutoMapper;
using GetHairdresser.Client.FormsAuth;
using GetHairdresser.Client.UserService;
using GetHairDresser.Common.BL.Entities;
using GetHairdresser.Client.ExternalWrappers;


namespace GetHairdresser.Client.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        private IUserService serviceUser;
        private IOAuthWeb webLogging;

        public AccountController()
        {
            this.serviceUser = new UserServiceClient();
            this.webLogging = new OAuthWeb();
        }

        public AccountController(IUserService service)
        {
            this.serviceUser = service;
        }
        public AccountController(IOAuthWeb webLoging)
        {
            this.webLogging = webLoging;
        }
        public AccountController(IUserService service, IOAuthWeb webLoging)
        {
            this.serviceUser = service;
            this.webLogging = webLoging;
        }


        AuthentificManager authentifManag = new AuthentificManager();

        [AllowAnonymous]
        public ActionResult Manage(string url)
        {
            serviceUser = new UserServiceClient();
            User user = serviceUser.GetUserData(new Guid(authentifManag.AuthGuid));
            if (user != null)
            {
                if (user.typeClient == ClientCategory.Category.client.ToString())
                {
                    return RedirectToAction("Index", "Client");
                }

                if (user.typeClient == ClientCategory.Category.hairdress.ToString())
                {
                    return RedirectToAction("Index", "Hairdress");
                }

            }
            return RedirectToAction("Index", "Home");

        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            
            authentifManag.LogOut();
            return RedirectToAction("Index", "Home");
        }
       
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        
        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            User myUser;
            AuthentificManager authentifManag = new AuthentificManager();
            AuthenticationResult result = webLogging.VerifyAutentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (authentifManag.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            
                
            //Get facebook token 
            string accesstoken = result.ExtraData["accesstoken"].ToString();
            var client = new Facebook.FacebookClient(accesstoken);
            dynamic fbresult = client.Get("me");
            //deserialize it
            JavaScriptSerializer jss = new JavaScriptSerializer();
            dynamic objData = jss.Deserialize<dynamic>(fbresult.ToString());
                


            //Take data from token
            UserProfile model = new UserProfile()
            {
                gender = result.ExtraData["gender"],
                lastName = objData["last_name"].ToString(),
                firstName = objData["first_name"].ToString(),
                location = objData["location"]["name"].ToString(),
                UserFacebook = result.ProviderUserId
            };

            //See if user is registered already or not
            serviceUser = new UserServiceClient();
            
            bool exist = serviceUser.Login(UserMap(model));
            if (exist == true)
            {
                myUser = serviceUser.GetUserDataByFacebook(model.UserFacebook);

                string userType = serviceUser.GetUserType(myUser);
                authentifManag.Login(myUser, false);
                ViewBag.ReturnUrl = returnUrl;

                if (userType == ClientCategory.Category.client.ToString())
                {
                    return RedirectToAction("Index", "Client");
                }

                if (userType == ClientCategory.Category.hairdress.ToString())
                {
                    return RedirectToAction("Index", "Hairdress");
                }
                // go to error
                    return null;
            }
            

            return View("ExternalLoginConfirmation", model);
            
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(UserProfile model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                return View("SetExternalCategory", model);   
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SetExternalCategory(UserProfile model,string typeClient)
        {
            
           
                serviceUser = new UserServiceClient();
                User register_user = UserMap(model);
                register_user.UserGuid = Guid.NewGuid();
                authentifManag.Login(UserMap(model), false);
                register_user.typeClient = typeClient;
                serviceUser.Register(register_user);

                if (typeClient == ClientCategory.Category.client.ToString())
                {
                    return RedirectToAction("Index", "Client");
                }
                if (typeClient == ClientCategory.Category.hairdress.ToString())
                {
                    return RedirectToAction("Index", "Hairdress");
                }


            return View();
        }


        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }
        #region Mappers
        public static User UserMap(UserProfile user)
        {
            return new GetHairDresser.Common.User()
            {
                UserId = user.UserId,
                age = user.age,
                email = user.email,
                firstName = user.firstName,
                lastName = user.lastName,
                location = user.location,
                typeClient = user.typeClient,
                UserFacebook = user.UserFacebook,
                UserGuid = user.UserGuid
            };
        }
        public static UserProfile UserProfileMap(User user)
        {
            return new UserProfile()
            {
                UserId = user.UserId,
                age = user.age,
                email = user.email,
                firstName = user.firstName,
                lastName = user.lastName,
                location = user.location,
                typeClient = user.typeClient,
                UserFacebook = user.UserFacebook,
                UserGuid = user.UserGuid
            };
        }
        #endregion


        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        [AllowAnonymous]
        public ActionResult SetExternalCategory()
        {
            
                return View("SetExternalCategory");
        }

        

        #endregion
    }
}
