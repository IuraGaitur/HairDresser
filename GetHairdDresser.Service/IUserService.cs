using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GetHairdDresser.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool Login(User user);
        [OperationContract]
        bool Register(User u);
        [OperationContract]
        User GetUserData(Guid id);
        [OperationContract]
        User GetUserDataByFacebook(string facebookId);
        [OperationContract]
        bool EditData(User user);
        [OperationContract]
        string GetUserType(User user);
        [OperationContract]
        bool SetUserType(User user, string userType);
    }
}
