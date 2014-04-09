using GetHairdresser.Client.UserService;
using GetHairDresser.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairdresser.Client.FormsAuth
{
    public interface IAccountRepository
    {
        User GetUserByGuid(string guid);
    }
}
