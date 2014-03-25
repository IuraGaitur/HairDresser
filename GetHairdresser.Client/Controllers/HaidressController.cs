using GetHairdresser.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetHairdresser.Client.Controllers
{
    public class HaidressController : Controller
    {
        //
        // GET: /Haidress/

        public ActionResult HairDressProfile(UserProfile model)
        {
            return View();
        }

    }
}
