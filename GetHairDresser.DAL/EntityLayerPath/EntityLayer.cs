using GetHairDresser.DAL.Interfaces;
using GetHairDresser.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.DAL.EntityLayerPath
{
    public class EntityLayer:IRepository
    {

        public void AddUser(User user)
        {
            using (var db = new EntityLayerDB())
            {
                db.users.Add(user);
                db.SaveChanges();
            }
        }

        public void EditUser(User user)
        {
            var db = new EntityLayerDB();
            var _user = db.users.FirstOrDefault(x => x.UserId == user.UserId);
            _user.firstName = user.firstName;
            _user.lastName = user.lastName;
            _user.email = user.email;
            _user.location = user.location;
            _user.JobAppointments = user.JobAppointments;
            db.SaveChanges();

        }

        public void DeleteUser(int id)
        {
            var db = new EntityLayerDB();
            User delUser = db.users.FirstOrDefault(x => x.UserId == id);
            db.users.Remove(delUser);
            db.SaveChanges();
        }

        public void AddJobAppointment(BL.JobAppointment jobapp)
        {
            using (var db = new EntityLayerDB())
            {
                db.jobAppoints.Add(jobapp);
                db.SaveChanges();
            }
        }

        public void EditJobAppointment(BL.JobAppointment jobapp)
        {
            var db = new EntityLayerDB();
            var findJobApp = db.jobAppoints.FirstOrDefault(x => x.JobAppID == jobapp.JobAppID);
            findJobApp.Hairdresser = jobapp.Hairdresser;
            findJobApp.HourJob = jobapp.HourJob;
            findJobApp.Status = jobapp.Status;
            findJobApp.DateJob = jobapp.DateJob;
            db.SaveChanges();
        }

        public void DeleteJobAppointment(int id)
        {
            var db = new EntityLayerDB();
            JobAppointment delJobAppoint = db.jobAppoints.FirstOrDefault(x => x.JobAppID == id);
            db.jobAppoints.Remove(delJobAppoint);
            db.SaveChanges();
        }

        private void LogOut()
        {

        }
        public void GetUserByGuid(Guid guid)
        {

            var db = new EntityLayer();

        }



        
    }
}
