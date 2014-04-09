using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetHairdresser.Client.FormsAuth
{
    public class AuthentificManager
    {
        private  FormsAuthentificationService service= new FormsAuthentificationService();

        public AuthentificManager()
        {
        }

        public bool Login(User user, bool remember)
        {
            service.Login(user, remember);

            return true;
        }
        public bool LogOut()
        {
            service.Logoff();

            return true;
        }
        public string AuthGuid
        {
            get { return service.CurrentUser; }
        }

        public bool IsAuthenticated 
        { 
            get
            {
                return (service.CurrentUser != null);
            }
        }
    }
}