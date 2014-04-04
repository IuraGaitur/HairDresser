using GetHairdresser.Client.UserServices;
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
