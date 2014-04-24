using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common;
using GetHairDresser.Common.Interfaces;
using GetHairDresser.Common.Entities;
using GetHairDresser.Common.DAL.Entities;


namespace GetHairDresser.DAL.EntityLayerPath
{
    public class EntityLayer:IRepository
    {





        //Users

        public void AddUser(UserDTO user)
        {
            using (var db = new EntityLayerDB())
            {
                db.users.Add(user);
                db.SaveChanges();
            }
        }

        public void EditUser(UserDTO user)
        {
            var db = new EntityLayerDB();
            var _user = db.users.FirstOrDefault(x => x.UserId == user.UserId);
            _user.firstName = user.firstName;
            _user.lastName = user.lastName;
            _user.age = user.age;
            _user.email = user.email;
            _user.gender = user.gender;
            _user.location = user.location;
            _user.JobAppointments = user.JobAppointments;
            db.SaveChanges();

        }

        public void DeleteUser(int id)
        {
            var db = new EntityLayerDB();
            UserDTO delUser = db.users.FirstOrDefault(x => x.UserId == id);
            db.users.Remove(delUser);
            db.SaveChanges();
        }

        public void AddJobAppointment(JobAppointmentDTO jobapp)
        {
            using (var db = new EntityLayerDB())
            {
                db.jobAppoints.Add(jobapp);
                db.SaveChanges();
            }
        }

        public void EditJobAppointment(JobAppointmentDTO jobapp)
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
            JobAppointmentDTO delJobAppoint = db.jobAppoints.FirstOrDefault(x => x.JobAppID == id);
            db.jobAppoints.Remove(delJobAppoint);
            db.SaveChanges();
        }


        public UserDTO GetUser(Guid id)
        {
            var db = new EntityLayerDB();

            UserDTO person = db.users.FirstOrDefault(x => x.UserGuid == id);

            return person;

            //return new User()
            //{
            // age = person.age,
            // email = person.email,
            // firstName = person.email,
            // gender = person.gender,
            // JobAppointments = person.JobAppointments,
            // lastName = person.lastName,
            // location = person.location,
            // typeClient = person.typeClient,
            // UserFacebook = person.UserFacebook,
            // UserGuid = person.UserGuid,
            // UserId = person.UserId
            //};
        }

        public UserDTO GetUserByFacebook(string facebookId)
        {
            var db = new EntityLayerDB();
            UserDTO person = db.users.FirstOrDefault(x => x.UserFacebook.Equals(facebookId));

            return person;
        }


        public List<UserDTO> GetUsers()
        {
            var db = new EntityLayerDB();
            List<UserDTO> users = db.users.ToList();
            return users;
        }

        public List<UserDTO> SearchUsers(string name)
        {
            var db = new EntityLayerDB();
            List<UserDTO> users = (from user in db.users
                                   where user.firstName.Contains(name) || user.lastName.Contains(name)
                                   select new UserDTO()
                                   {
                                       email = user.email,
                                       firstName = user.firstName,
                                       JobAppointments = user.JobAppointments,
                                       lastName = user.lastName,
                                       location = user.location,
                                       typeClient = user.typeClient,
                                       UserGuid = user.UserGuid,
                                       UserId = user.UserId
                                   }).ToList();

            return users;
        }


        //Job Appointements

        public List<JobAppointmentDTO> GetJobAppointmentsByDate(UserDTO user, DateTime date)
        {
            var db = new EntityLayerDB();
            //var jobs = (from job in db.jobAppoints
            //                                where (job.Hairdresser.UserId == user.UserId && job.DateJob == date)
            //                                select new JobAppointmentDTO()
            //                                {
            //                                    DateJob = job.DateJob,
            //                                    Hairdresser = job.Hairdresser,
            //                                    HourJob = job.HourJob,
            //                                    JobAppID = job.JobAppID,
            //                                    Status = job.Status
            //                                }).ToList();
            var jobs = db.jobAppoints.Where(job => (job.Hairdresser.UserId == user.UserId && job.DateJob == date)).ToList();

            return jobs;
        }

        public List<JobAppointmentDTO> GetJobAppointments(UserDTO user)
        {
            var db = new EntityLayerDB();
            List<JobAppointmentDTO> jobs = (from job in db.jobAppoints
                                            where (job.Hairdresser.UserId == user.UserId)
                                            select new JobAppointmentDTO()
                                            {
                                                DateJob = job.DateJob,
                                                Hairdresser = job.Hairdresser,
                                                HourJob = job.HourJob,
                                                JobAppID = job.JobAppID,
                                                Status = job.Status
                                            }).ToList();

            return jobs;
        }

        public List<JobAppointmentDTO> GetTypedJobAppointmentsByDate(UserDTO user, int status)
        {
            var db = new EntityLayerDB();
            List<JobAppointmentDTO> jobs = (from job in db.jobAppoints
                                            where (job.Hairdresser.UserId == user.UserId && job.Status == status)
                                            select new JobAppointmentDTO()
                                            {
                                                DateJob = job.DateJob,
                                                Hairdresser = job.Hairdresser,
                                                HourJob = job.HourJob,
                                                JobAppID = job.JobAppID,
                                                Status = job.Status
                                            }).ToList();

            return jobs;
        }

        //User type

        public void ChangeUserType(int id, string hairdresser)
        {
            var db = new EntityLayerDB();
            var usertype = db.users.FirstOrDefault(x => x.UserId == id);
            usertype.typeClient = hairdresser;
            db.SaveChanges();
        }

        public string GetUserType(int id)
        {
            var db = new EntityLayerDB();
            string type = db.users.FirstOrDefault(x => x.UserId == id).typeClient;
            return type;
        }


        //Messages

        public void AddMessage(MessageDTO message)
        {
            using (var db = new EntityLayerDB())
            {
                db.messages.Add(message);
                db.SaveChanges();
            }
        }

        public void EditMessage(MessageDTO message)
        {
            var db = new EntityLayerDB();
            var messages = db.messages.FirstOrDefault(x => x.MessageID == message.MessageID);
            messages.receiverID = message.receiverID;
            messages.senderID = message.receiverID;
            messages.text = message.text;
            db.SaveChanges();
        }

        public void DeleteMessage(int id)
        {
            var db = new EntityLayerDB();
            MessageDTO delMessage = db.messages.FirstOrDefault(x => x.MessageID == id);
            db.messages.Remove(delMessage);
            db.SaveChanges();
        }

        public List<MessageDTO> GetMessagesSend(int id)
        {
            var db = new EntityLayerDB();
            List<MessageDTO> messageSend = db.messages.Where(x => x.senderID.UserId == id).ToList();
            return messageSend;
        }

        public List<MessageDTO> GetMessagesReceived(int id)
        {
            var db = new EntityLayerDB();
            List<MessageDTO> messageSend = db.messages.Where(x => x.receiverID.UserId == id).ToList();
            return messageSend;
        }



        //Hairdress Info

        public void EditHairdressInfo(UserDTO user, HairdresInfoDTO info)
        {
            var db = new EntityLayerDB();
            var hairdressInfo = db.infoHairdress.FirstOrDefault(x => x.HairdressID.UserId == user.UserId);
            hairdressInfo.map_data = info.map_data;
            hairdressInfo.photo = info.photo;
            hairdressInfo.rating = info.rating;
            db.SaveChanges();
        }

        public void EditHairdressInfoMap(UserDTO user, string map)
        {
            var db = new EntityLayerDB();
            var hairdressInfo = db.infoHairdress.FirstOrDefault(x => x.HairdressID.UserId == user.UserId);
            hairdressInfo.map_data = map;
            db.SaveChanges();
        }

        public void EditHairdressInfoPhoto(UserDTO user, string photo)
        {
            var db = new EntityLayerDB();
            var hairdressInfo = db.infoHairdress.FirstOrDefault(x => x.HairdressID.UserId == user.UserId);
            hairdressInfo.photo = photo;
            db.SaveChanges();
        }

        public void EditHairdressInfoRating(UserDTO user, double rating)
        {
            var db = new EntityLayerDB();
            var hairdressInfo = db.infoHairdress.FirstOrDefault(x => x.HairdressID.UserId == user.UserId);
            hairdressInfo.rating = rating;
            db.SaveChanges();
        }

        public HairdresInfoDTO GetHairdressInfo(int id)
        {
            var db = new EntityLayerDB();
            var item = db.infoHairdress.ToList();
            HairdresInfoDTO info = db.infoHairdress.FirstOrDefault(x => x.HairdressID.UserId == id);
            return info;
        }

        public void DeleteHairdressInfo(UserDTO user)
        {
            var db = new EntityLayerDB();
            UserDTO delUser = db.users.FirstOrDefault(x => x.UserId == user.UserId);
            db.users.Remove(delUser);
            db.SaveChanges();
        }


        public List<UserDTO> GetAllHairdress()
        {
            var db = new EntityLayerDB();
            List<UserDTO> hairdress = db.users.Where(x => x.typeClient == "hairdress").ToList();
            foreach (UserDTO user in hairdress)
            {
                user.hairdressInfo = GetHairdressInfo(user.UserId);
            }
            return hairdress;
        }

        public List<UserDTO> GetAllHaidressLocation(string location)
        {
            var db = new EntityLayerDB();
            List<UserDTO> hairdress = db.users.Where(x => (x.typeClient == "hairdress" && x.location == location)).ToList();
            return hairdress;
        }
    }
}
