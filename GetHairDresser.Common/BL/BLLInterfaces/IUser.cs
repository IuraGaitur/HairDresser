using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairDresser.Common.BLLInterfaces
{
    public interface IUser
    {
        bool Login(User user);
        
        bool Register(User u);
        
        User GetUserData(Guid id);

        User GetUserByFacebook(string facebookId);

        bool EditData(User user);

        string GetUserType(User user);

        bool SetUserType(User user,string hairdress);

    }
}
