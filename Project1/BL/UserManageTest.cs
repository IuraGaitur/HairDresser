using GetHairDresser.BL;
using GetHairDresser.Common;
using GetHairDresser.Common.DAL.Entities;
using GetHairDresser.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetHairDresser.Tests
{
    [TestClass]
    public class UserManageTest
    {
        //UserBLL testUser = new UserBLL();
        User user = new User()
        {
            age = 12,
            email = "iura.gaitur@gmail.com",
            firstName = "Iurik",
            lastName = "Malinka",
            location = "Chetreni",
            typeClient = "client",
            UserFacebook = "132156423156",
            UserGuid = new Guid(),
        };

        [TestInitialize]
        void SetUp()
        {

        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Login_RepositoryThrowsException_InvalidOperationExcetion()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();

            repositoryMock.Setup(rep => rep.GetUserByFacebook("some string")).Throws<InvalidOperationException>();

            UserBLL userLogic = new UserBLL(repositoryMock.Object);

            userLogic.Login(new User() { UserFacebook = "some string" });
            
        }
        [TestMethod]
        public void Login_Past_With_Empty()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();

            repositoryMock.Setup(rep => rep.GetUserByFacebook(""));

            UserBLL userLogic = new UserBLL(repositoryMock.Object);

            userLogic.Login(new User() { UserFacebook = "" });

        }
        [TestMethod]
        public void RegisterNewUserTest()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();

            repositoryMock.Setup(rep => rep.GetUserByFacebook(""));

            UserBLL userLogic = new UserBLL(repositoryMock.Object);
            var userNull = userLogic.Register(user);
            Assert.IsTrue(userNull);


        }
        public void RegisterSameUserTest()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();

            repositoryMock.Setup(rep => rep.GetUserByFacebook(""));

            UserBLL userLogic = new UserBLL(repositoryMock.Object);
            var userPresent = userLogic.Register(user);
            Assert.IsFalse(userPresent);
        }
        [TestMethod]
        public void GetUserDataTest()
        {
            var guid = Guid.NewGuid();
            Mock<IRepository> repositoryMock = new Mock<IRepository>();

            UserBLL userLogic = new UserBLL(repositoryMock.Object);
            var userdata = userLogic.GetUserData(guid);
            Assert.Equals(userdata, user); // todo
            

        }
        [TestMethod]
        public void GetUserDataWhenEmptyTest()
        {
            Guid guid = new Guid(" ");
            Mock<IRepository> repositoryMock = new Mock<IRepository>();

            UserBLL userLogic = new UserBLL(repositoryMock.Object);
            var userdata = userLogic.GetUserData(guid);
            Assert.Equals(userdata, user); // todo


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
