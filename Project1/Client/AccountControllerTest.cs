using GetHairdDresser.Service;
using GetHairdresser.Client.Controllers;
using GetHairdresser.Client.ExternalWrappers;
using GetHairDresser.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetOpenAuth.AspNet;


namespace Project1.Client
{
    [TestClass]
    class AccountControllerTest
    {
        //AccountController controller;
        

        [TestMethod]
        public void ExternalLoginCallBackTest()
        {
            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(user => user.GetUserDataByFacebook("some string")).Throws<Exception>();
            //UserService



        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExternalLoginCallBack_AuthorizeNotConnected_ThrowsException()
        {
            Mock<IOAuthWeb> authorizeMock = new Mock<IOAuthWeb>();
            authorizeMock.Setup(auth => auth.VerifyAutentication("some string")).Throws<Exception>();

            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(user => user.GetUserDataByFacebook("some string")).Throws<Exception>();

            AccountController accountController = new AccountController(authorizeMock.Object);
            accountController.ExternalLogin(null, null);

        }



        [TestMethod]
        public void ExternalLoginCallBack_UserNotExist_RedirectRegister()
        {
            Mock<IOAuthWeb> authorizeMock = new Mock<IOAuthWeb>();
            authorizeMock.Setup(auth => auth.VerifyAutentication("some string")).Returns(new AuthenticationResult(true,"facebook","","",null));
            
            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(user => user.Login(new User())).Returns(false);

        }

        [TestMethod]
        public void ExternalLoginCallBack_UserExist_GetUser()
        {
            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(user => user.

        }

    }
}
