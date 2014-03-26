using GetHairDresser.Common.Mapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common;
using GetHairDresser.Common.DAL.Entities;
using AutoMapper;

namespace GetHairDresser.BL.Mapper
{
    /// <summary>
    /// Map for User
    /// </summary>
    public class UserMapper:IMapperUser
    {
        public UserMapper()
        {
            AutoMapper.Mapper.CreateMap<UserDTO, User>();
            AutoMapper.Mapper.CreateMap<User,UserDTO>();
        }
        public UserDTO MapUserDTO(User user)
        {
            return AutoMapper.Mapper.Map<UserDTO>(user);
        }

        public User MapUser(UserDTO user)
        {
            return AutoMapper.Mapper.Map<User>(user);
        }
    }
}
