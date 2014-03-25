using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetHairDresser.Common;
using GetHairDresser.Common.BLLInterfaces;
using GetHairDresser.DAL;
using GetHairDresser.Common.Interfaces;
using AutoMapper;
using GetHairDresser.Common.DAL.Entities;

namespace GetHairDresser.BL
{
    public class UserBLL:IUser
    {
        public UserBLL()
        {
            Mapper.CreateMap<User, UserDTO>();
            Mapper.CreateMap<UserDTO, User>();
        }

        IRepository repository = RepositoryLocator.GetRepository();
        
        public bool Login(User user)
        {
            UserDTO temp_user = new UserDTO();
            Mapper.DynamicMap(user,temp_user);
            temp_user = repository.GetUserByFacebook(temp_user.UserFacebook);
            if (temp_user == null)
                return false;
            return true;
        }

        public bool Register(User u)
        {
            UserDTO temp_user = Mapper.Map<UserDTO>(u);
            UserDTO registred = repository.GetUserByFacebook(temp_user.UserFacebook);
            if (registred == null)
            {
                repository.AddUser(temp_user);
                return true;
            }
            return false;
        }

        public User GetUserData(Guid id)
        {
            User user = null;
            UserDTO temp_user;
            if (id != null)
            {
                temp_user = repository.GetUser(id);
                user = Mapper.Map<User>(temp_user);
            }

           return user;
        }


        public User GetUserByFacebook(string facebookId)
        {
            User user = null;
            UserDTO temp_user;
            if (facebookId != null)
            {
                temp_user = repository.GetUserByFacebook(facebookId);
                user = Mapper.Map<User>(temp_user);
            }

           return user;
        }


        public bool EditData(User user)
        {
            if (user != null)
            {
                UserDTO temp_user = Mapper.Map<UserDTO>(user);
                repository.EditUser(temp_user);
                return true;
            }
            return false;
        }
        public string GetUserType(User user)
        {
            string type = null;
            if (user != null)
                type = repository.GetUserType(user.UserId);
            return type;
        }

        public bool SetUserType(User user,string hairdress)
        {
            if (user != null)
            {
                repository.ChangeUserType(user.UserId, hairdress);
                return true;
            }
            return false;

        }
    }
}
