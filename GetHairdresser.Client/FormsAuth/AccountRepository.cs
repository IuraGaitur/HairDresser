using GetHairdresser.Client.UserService;
using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetHairdresser.Client.FormsAuth
{
    public class AccountRepository:IAccountRepository
    {
        UserServiceClient userClient = new UserService.UserServiceClient();
        public User GetUserByGuid(string guid)
        {
            return userClient.GetUserData(new Guid(guid));
        }
    }
}