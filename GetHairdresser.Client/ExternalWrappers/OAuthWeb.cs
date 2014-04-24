using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace GetHairdresser.Client.ExternalWrappers
{
    public class OAuthWeb:IOAuthWeb
    {

        public AuthenticationResult VerifyAutentication(string returnUrl)
        {
            return OAuthWebSecurity.VerifyAuthentication(returnUrl);
        }
    }
}