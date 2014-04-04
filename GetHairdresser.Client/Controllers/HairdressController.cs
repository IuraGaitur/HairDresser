using GetHairdresser.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetHairdresser.Client.Controllers
{
    public class HairdressController : Controller
    {
        //
        // GET: /Haidress/

        public ActionResult Index(UserProfile model)
        {
            return View("HairDressProfile");
        }

    }
}
