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
using GetHairDresser.Common.Mapper.Interfaces;
using GetHairDresser.BL.Mapper;

namespace GetHairDresser.BL
{
    public class UserBLL:IUserManage
    {
        IMapperUser mapper;
        IRepository repository;
        public UserBLL(IRepository repository)
        {
            mapper = new UserMapper();
            this.repository = repository;            
        }

        //IRepository repository = RepositoryLocator.GetRepository();
        
        public bool Login(User user)
        {
            UserDTO temp_user = new UserDTO();

            temp_user = repository.GetUserByFacebook(user.UserFacebook);

            if (temp_user == null)
                return false;

            return true;
        }

        public bool Register(User u)
        {
            UserDTO registred = repository.GetUserByFacebook(u.UserFacebook);

            if (registred == null)
            {
                
                repository.AddUser(mapper.MapUserDTO(u));
                return true;
            }
            return false;
        }

        public User GetUserData(Guid id)
        {
            UserDTO temp_user = null;
            if (id != null)
            {
                temp_user = repository.GetUser(id);
                
            }

           return mapper.MapUser(temp_user);
        }


        public User GetUserByFacebook(string facebookId)
        {
            
            UserDTO temp_user = null;
            if (facebookId != null)
            {
                temp_user = repository.GetUserByFacebook(facebookId);
                
            }

           return mapper.MapUser(temp_user);
        }


        public bool EditData(User user)
        {
            if (user != null)
            {
                
                repository.EditUser(mapper.MapUserDTO(user));
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
        public List<User> GetAllHairdress()
        {

            List<User> my_users = new List<User>();
            List<UserDTO> temp_users  = repository.GetAllHairdress();
            foreach (UserDTO user in temp_users)
            {
                my_users.Add(mapper.MapUser(user));
            }


            return my_users;
        }






        public List<User> GetAllHaidressLocation(string location)
        {
            List<User> my_users = null;
            List<UserDTO> temp_users = repository.GetAllHaidressLocation(location);
            foreach (UserDTO user in temp_users)
            {
                my_users.Add(mapper.MapUser(user));
            }


            return my_users;
        }
    }
}
