using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using GetHairdresser.Client.UserService;
using GetHairDresser.Common;

namespace GetHairdresser.Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";
            ViewBag.Title = "Find your hairdress today";
            UserServiceClient service = new UserServiceClient();
            IEnumerable<User> hairdressers = service.GetAllHairdress();

            ViewBag.Hairdressers = hairdressers;
      
            return View();

            //User user = new User();
            //user.firstName = "iura";
            //user.lastName = "vasea";
            //user.typeClient = "hairdress";
            //user.age = 16;
            //user.email = "asdasd";
            //user.gender = "sadas";
            //user.hairdressInfo.rating = 6.5;
            //user.hairdressInfo.photo = "asd";
            //user.location = "asd";
            //user.UserGuid = new Guid("620961d7-2a0f-4dbc-9ee2-f1449be3da4f");
            //user.UserFacebook = "231312";
            //service.Register(user);


        }
        [HttpGet]
        public ActionResult Edit()
        {


            //"_EditClientData",
            return PartialView();
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {


            return PartialView();
        }



    }
}
