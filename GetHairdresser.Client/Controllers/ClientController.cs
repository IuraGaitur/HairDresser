using GetHairdresser.Client.FormsAuth;
using GetHairdresser.Client.Models;
using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GetHairdresser.Client.Controllers
{
    public class ClientController : Controller
    {
        AuthentificManager authentifManager = new AuthentificManager();
        //
        // GET: /Client/
        UserProfile model = null;

        public ActionResult Index()
        {
            using (UserService.UserServiceClient client = new UserService.UserServiceClient())
            {

                AccountController controller = new AccountController();
                string guid = authentifManager.AuthGuid;
                User user = client.GetUserData(new Guid(guid));
                model = AccountController.UserProfileMap(user);
            }

            return View("ClientPage", model);
        }

    }
}
