using DotNetOpenAuth.AspNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHairdresser.Client.ExternalWrappers
{
    public interface IOAuthWeb
    {
        AuthenticationResult VerifyAutentication(string url);

    }
}
