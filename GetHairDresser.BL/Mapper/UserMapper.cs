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
        HairdressInfoMapper hairdressMapper;
        MessageMapper messageMapper;
        public UserMapper()
        {
            AutoMapper.Mapper.CreateMap<UserDTO, User>();
            AutoMapper.Mapper.CreateMap<User,UserDTO>();
            hairdressMapper = new HairdressInfoMapper();
            messageMapper = new MessageMapper();



        }
        public UserDTO MapUserDTO(User user)
        {
            return AutoMapper.Mapper.Map<UserDTO>(user);
        }

        public User MapUser(UserDTO user)
        {
            //return AutoMapper.Mapper.Map<User>(user);
            return new User
            {
                age = user.age,
                email = user.email,
                firstName = user.firstName,
                lastName = user.lastName,
                location = user.location,
                //receivedListMessages = messageMapper.MapMessage(user.receivedListMessages.ToList()),
                //sendListMessages = messageMapper.MapMessage(user.sendListMessages),
                typeClient = user.typeClient,
                UserFacebook = user.UserFacebook,
                UserGuid = user.UserGuid,
                UserId = user.UserId,
                hairdressInfo = hairdressMapper.MapHairdressInfo(user.hairdressInfo)
            };

        }
    }
}
