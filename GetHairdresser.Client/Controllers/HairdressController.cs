using GetHairdresser.Client.UserService;
using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetHairdresser.Client.JobAppointmentsService;
using GetHairdresser.Client.FormsAuth;

namespace GetHairdresser.Client.Controllers
{
    public class HairdressController : Controller
    {
        //
        // GET: /Haidress/

        public ActionResult Index(string guidId)
        {
            UserServiceClient service = new UserServiceClient();
            if (String.IsNullOrEmpty(guidId))
            {
                
                IEnumerable<User> hairdressers = service.GetAllHairdress();

                ViewBag.Hairdressers = hairdressers;

                return View("HairdresserList");
            }


            JobAppointmentsServiceClient jobService = new JobAppointmentsServiceClient();
            IEnumerable<JobAppointment> jobs = jobService.GetJobAppointmentsByDate(new User(), DateTime.Now);
            
            ViewBag.Title = "HairDressProfile";
            ViewBag.Hairdress = service.GetUserData(new Guid(guidId));
            ViewBag.JobAppointments = jobs;
            return View("HairdresserPage");

        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetJobAppoints()
        {

            UserServiceClient service = new UserServiceClient();
            JobAppointmentsServiceClient jobService = new JobAppointmentsServiceClient();
            FormsAuthentificationService serviceAuth = new FormsAuthentificationService();
            string userGuid = serviceAuth.CurrentUser;
            User user = service.GetUserData(new Guid(userGuid));
            var jobs = jobService.GetJobAppointments(user);

            var json = Json(jobs,JsonRequestBehavior.AllowGet);
            return json;
        }
        
        


    }
}


