using GetHairdresser.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GetHairdresser.Client.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        UserProfile model = null;

        public ActionResult Index()
        {
            using (UserServices.UserServiceClient client = new UserServices.UserServiceClient())
            {

                AccountController controller = new AccountController();
                string guid = controller.GetGuidIdFromCookies();
                UserServices.User user = client.GetUserData(new Guid(guid));
                model = AccountController.UserProfileMap(user);
            }

            return View(model);
        }

    }
}
