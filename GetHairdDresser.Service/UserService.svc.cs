using GetHairDresser.BL;
using GetHairDresser.Common;
using GetHairDresser.Common.BLLInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
      private IUserManage myUser { get; set; }

        public UserService()
        {
            myUser = new UserBLL();
        }
        
        public bool Login(User user)
        {
            return myUser.Login(user);
        }

        public bool Register(User u)
        {
            return myUser.Register(u);
        }

        public User GetUserData(Guid id)
        {
            return myUser.GetUserData(id);
        }

        public User GetUserDataByFacebook(string facebookId)
        {
            User user = myUser.GetUserByFacebook(facebookId);
            return user;
        }

        public bool EditData(User user)
        {
            return myUser.EditData(user);
        }
        public string GetUserType(User user)
        {
            return myUser.GetUserType(user);
        }
        public bool SetUserType(User user, string userType)
        {
            return myUser.SetUserType(user, userType);
        }


    }
}
