using GetHairdresser.Client.Models;
using GetHairdresser.Client.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairdresser.Client.FormsAuth
{
    public interface IAuthentificationService
    {
        void Login(User user, bool rememberMe);

        void Logoff();

        string GeneratePassword(string pass, string salt);

        User CurrentUser { get; }
    }
}
