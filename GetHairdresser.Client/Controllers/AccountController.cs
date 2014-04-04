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
using GetHairdresser.Client.UserServices;
using AutoMapper;


namespace GetHairdresser.Client.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            
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

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            return RedirectToAction("Index", "Home");
        }
        #region AuthCode
        ////
        //// GET: /Account/Register

        //[AllowAnonymous]
        //public ActionResult Register()
        //{
            
        //    return View();
        //}

        ////
        //// POST: /Account/Register

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Attempt to register the user
        //        try
        //        {
        //            WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
        //            WebSecurity.Login(model.UserName, model.Password);
        //            return RedirectToAction("About", "Account");
        //        }
        //        catch (MembershipCreateUserException e)
        //        {
        //            ModelState.AddModelError("SetExternalCategory", ErrorCodeToString(e.StatusCode));
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// POST: /Account/Disassociate

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Disassociate(string provider, string providerUserId)
        //{
        //    string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
        //    ManageMessageId? message = null;

        //    // Only disassociate the account if the currently logged in user is the owner
        //    if (ownerAccount == User.Identity.Name)
        //    {
        //        // Use a transaction to prevent the user from deleting their last login credential
        //        using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
        //        {
        //            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
        //            if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
        //            {
        //                OAuthWebSecurity.DeleteAccount(provider, providerUserId);
        //                scope.Complete();
        //                message = ManageMessageId.RemoveLoginSuccess;
        //            }
        //        }
        //    }

        //    return RedirectToAction("Manage", new { Message = message });
        //}

        ////
        //// GET: /Account/Manage

        //public ActionResult Manage(ManageMessageId? message)
        //{
        //    ViewBag.StatusMessage =
        //        message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
        //        : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
        //        : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
        //        : "";
        //    ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    return View();
        //}

        ////
        //// POST: /Account/Manage

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Manage(LocalPasswordModel model)
        //{
        //    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
        //    ViewBag.HasLocalPassword = hasLocalAccount;
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    if (hasLocalAccount)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // ChangePassword will throw an exception rather than return false in certain failure scenarios.
        //            bool changePasswordSucceeded;
        //            try
        //            {
        //                changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
        //            }
        //            catch (Exception)
        //            {
        //                changePasswordSucceeded = false;
        //            }

        //            if (changePasswordSucceeded)
        //            {
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // User does not have a local password so remove any validation errors caused by a missing
        //        // OldPassword field
        //        ModelState state = ModelState["OldPassword"];
        //        if (state != null)
        //        {
        //            state.Errors.Clear();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
        //            }
        //            catch (Exception e)
        //            {
        //                ModelState.AddModelError("", e);
        //            }
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //
        // POST: /Account/ExternalLogin

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        //}

        //
        // GET: /Account/ExternalLoginCallback
        #endregion
        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            User myUser;

            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToAction("SetExternalCategory");
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;

                //Get facebook token 
                string accesstoken = result.ExtraData["accesstoken"].ToString();
                var client = new Facebook.FacebookClient(accesstoken);
                dynamic fbresult = client.Get("me");

                //OAuthWebSecurity.CreateOrUpdateAccount(
                JavaScriptSerializer jss = new JavaScriptSerializer();

                dynamic objData = jss.Deserialize<dynamic>(fbresult.ToString());



                //Take data from token
                UserProfile model = new UserProfile()
                {
                    ExternalLoginData = loginData,
                    gender = result.ExtraData["gender"],
                    lastName = objData["last_name"].ToString(),
                    firstName = objData["first_name"].ToString(),
                    location = objData["location"]["name"].ToString(),
                    UserFacebook = result.ProviderUserId
                };

                //See if user is registered already or not
                using (UserServiceClient serviceUser = new UserServiceClient())
                {

                    bool exist = serviceUser.Login(UserMap(model));
                    if (exist == true)
                    {
                        myUser = serviceUser.GetUserDataByFacebook(model.UserFacebook);
                        string userType = serviceUser.GetUserType(myUser);
                        if (userType == "client")
                        {
                            return RedirectToAction("Index", "Client");
                            //return View("~/Views/Client/ClientPage.cshtml");
                        }
                        else if (userType == "hairdress")
                        {
                            return RedirectToAction("Index", "Hairdress");
                            //return View("~/Views/Hairdress/HairDressProfile.cshtml");
                        }
                    }
                }

                return View("ExternalLoginConfirmation", model);
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(UserProfile model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;
            
            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
       
                //OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                //OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                return View("SetExternalCategory", model);
                
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SetExternalCategory(UserProfile model,string typeClient)
        {
            

           
            using (UserServiceClient serviceUser = new UserServiceClient())
            {
                User register_user = UserMap(model);
                register_user.UserGuid = new Guid();
                AddGuidIdInCookies(register_user.UserGuid.ToString());
                if (typeClient == "client")
                {
                    register_user.typeClient = typeClient;
                    serviceUser.Register(register_user);
                    return RedirectToAction("Index", "Client");
                    //return View("~/Views/Client/ClientPage.cshtml");
                }
                else if (typeClient == "hairdresser")
                {
                    serviceUser.SetUserType(register_user,typeClient);
                    serviceUser.Register(register_user);
                    return RedirectToAction("Index", "Hairdress");
                    //return View("~/Views/Hairdress/HairDressProfile.cshtml");
                }
            }
            return View();
            
        }

        #region cookies
        //public void AddGuidIdInCookies(string guidId)
        //{
        //    HttpCookie cookieRelateUser = new HttpCookie("Client gui");
        //    cookieRelateUser["guid"] = guidId;
        //    cookieRelateUser.Expires = DateTime.Now.AddDays(1);
        //    Response.Cookies.Add(cookieRelateUser);
        //}
        //public String GetGuidIdFromCookies()
        //{
        //    string userSettings = null;
        //    if (Request.Cookies["Client gui"] != null)
        //    {
                
        //        if (Request.Cookies["Client gui"]["guid"] != null)
        //        { 
        //            userSettings = Request.Cookies["Client gui"]["guid"]; 
        //        }
        //    }

        //    return userSettings;
        //}
        //public void DeleteCookie()
        //{
        //    if (Request.Cookies["Client gui"] != null)
        //    {
        //        HttpCookie myCookie = new HttpCookie("guid");
        //        myCookie.Expires = DateTime.Now.AddDays(-1d);
        //        Response.Cookies.Add(myCookie);
        //    }
        //}

        #endregion



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

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
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
            return new User()
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
