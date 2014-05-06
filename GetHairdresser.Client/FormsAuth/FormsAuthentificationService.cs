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
        IAuthentificationService service;
        private string _currentUserGuid;
        private string _currentUserRole;

        public FormsAuthentificationService()
        {

        }

        public FormsAuthentificationService(IAccountRepository repository)
        {
            this.repository = repository;

        }
        public FormsAuthentificationService(IAuthentificationService service)
        {
            this.service = service;
        }


        public void Login(User user, bool rememberMe)
        {
            DateTime expiresDate = DateTime.Now.AddMinutes(30);
            if (rememberMe)
                expiresDate.AddDays(10);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
               1, user.typeClient.ToString(), DateTime.Now, expiresDate, rememberMe, user.UserGuid.ToString());
            string EncryptedTicket = FormsAuthentication.Encrypt(ticket);
            SetValue(AuthCookieName,EncryptedTicket,expiresDate);
            _currentUserGuid = user.UserGuid.ToString();

        }

        public void Logoff()
        {
            SetValue(AuthCookieName,null,DateTime.Now.AddYears(-1));
            CurrentUser = null;
            
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
                            _currentUserGuid = ticket.UserData;
                            _currentUserRole = ticket.Name;
                        }
                    }
                    catch(Exception e)
                    {
                        _currentUserGuid = null;
                    }
                 }
                return _currentUserGuid;
                }
            set{
                if (value == null)
                {
                    _currentUserGuid = value;
                }
            }
        }

        public string CurrentUserRole
        {
            get { return _currentUserRole; }
        }

        public void SetValue(string cookieName,string cookieObject,DateTime dateStoreTo)
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