﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetHairdresser.Client.FormsAuth
{
    public enum UserRoles
    {
        None = 1,
        Client = 2,
        Hairdress = 3

    };
    public static class RolesHelper
    {
        private static UserRoles[] _roles = null;
        public static UserRoles[] GetRoles()
        {
            if (_roles == null || _roles.Length == 0)
            {
                UserRoles[] roles = Enum.GetValues(typeof(UserRoles)) as UserRoles[];
                List<UserRoles> rolesToArr = new List<UserRoles>();
                foreach (UserRoles userRolese in roles)
                {
                    if (userRolese != UserRoles.None)
                    {
                        rolesToArr.Add(userRolese);
                    }
                }

                _roles = rolesToArr.ToArray();
            }

            return _roles;

        }
    }
}