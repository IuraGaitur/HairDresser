using GetHairDresser.BL;
using GetHairDresser.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetHairDresser.Tests
{
    [TestClass]
    public class UserManageTest
    {
        UserBLL testUser = new UserBLL();
        User user = new User()
        {
            age = 12,
            email = "",
            firstName = "",
            lastName = "",
            location = "",
            typeClient = "",
            UserFacebook = "",
            UserGuid = new Guid(),
        };
        
        [TestMethod]
        public void LoginTest()
        {
            
           bool test = testUser.Login(user);

            //Assert.IsNotNull(user
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void RegisterTest()
        {


        }
        [TestMethod]
        public void GetUserDataTest()
        {


        }
        [TestMethod]
        public void GetUserByFacebookTest()
        {


        }
        [TestMethod]
        public void EditDataTest()
        {



        }
        [TestMethod]
        public void GetUserTypeTest()
        {


        }
        [TestMethod]
        public void SetUserTypeTest()
        {



        }
    }

   

}
