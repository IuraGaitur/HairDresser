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
        private UserServices.User _currentUser;

        public FormsAuthentificationService(IAccountRepository repository)
        {
            this.repository = repository;
        }


        public void Login(UserServices.User user, bool rememberMe)
        {
            DateTime expiresDate = DateTime.Now.AddMinutes(30);
            if (rememberMe)
                expiresDate.AddDays(10);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
               1,user.firstName,DateTime.Now,expiresDate,rememberMe,user.UserId.ToString());
            string EncryptedTicket = FormsAuthentication.Encrypt(ticket);
            SetValue(AuthCookieName,null,expiresDate);
            _currentUser = user;

        }

        public void Logoff()
        {
            SetValue(AuthCookieName,null,DateTime.Now.AddYears(-1);
            _currentUser = null;
        }

        public string GeneratePassword(string pass, string salt)
        {
            return null;
        }

        public UserServices.User CurrentUser
        {
            get { 
                 if(_currentUser == null)
                 {
                    try
                    {
                        object cookie = HttpContext.Current.Request[AuthCookieName] != null ? HttpContext.Current.Request.Cookies[AuthCookieName].Value : null;
                        if(cookie != null && !String.IsNullOrEmpty(cookie.ToString()))
                        {
                            var ticket = FormsAuthentication.Decrypt(cookie.ToString());
                            _currentUser = repository.GetUserByGuid(ticket.Name.ToString());

                        }
                    }
                    catch(Exception e)
                    {
                        _currentUser = null;
                    }
                 }
                 return _currentUser;
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