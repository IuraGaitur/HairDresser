using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GetHairdresser.Client.FormsAuth
{
    public class FormsAuthentificationService:IAuthentificationService
    {
        private const string AuthCookieName = "AuthCookie";
        private IAccountRepository repository;
        private string _currentUserGuid;

        public FormsAuthentificationService()
        {

        }

        public FormsAuthentificationService(IAccountRepository repository)
        {
            this.repository = repository;
        }


        public void Login(User user, bool rememberMe)
        {
            DateTime expiresDate = DateTime.Now.AddMinutes(30);
            if (rememberMe)
                expiresDate.AddDays(10);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
               1, user.UserGuid.ToString(), DateTime.Now, expiresDate, rememberMe, user.UserGuid.ToString());
            string EncryptedTicket = FormsAuthentication.Encrypt(ticket);
            SetValue(AuthCookieName,user.UserGuid.ToString(),expiresDate);
            _currentUserGuid = user.UserGuid.ToString();

        }

        public void Logoff()
        {
            SetValue(AuthCookieName,null,DateTime.Now.AddYears(-1));
            _currentUserGuid = null;
        }


        public string CurrentUser
        {
            get {
                if (_currentUserGuid == null)
                 {
                    try
                    {
                        object cookie = HttpContext.Current.Request[AuthCookieName] != null ? HttpContext.Current.Request.Cookies[AuthCookieName].Value : null;
                        if(cookie != null && !String.IsNullOrEmpty(cookie.ToString()))
                        {
                            var ticket = FormsAuthentication.Decrypt(cookie.ToString());
                            _currentUserGuid = ticket.Name;

                        }
                    }
                    catch(Exception e)
                    {
                        _currentUserGuid = null;
                    }
                 }
                return _currentUserGuid;
                }
        }
        public static void SetValue(string cookieName,string cookieObject,DateTime dateStoreTo)
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies[cookieName];
            if(cookie == null)
            {
                cookie = new HttpCookie(cookieName);
                cookie.Path = "/";
            }
            cookie.Value = cookieObject;
            cookie.Expires = dateStoreTo;

            HttpContext.Current.Response.SetCookie(cookie);

        }


    }
}