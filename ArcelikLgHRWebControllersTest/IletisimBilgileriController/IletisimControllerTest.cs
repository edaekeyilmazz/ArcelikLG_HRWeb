using ArcelikLgHRWeb.Controllers;
using ArcelikLgHRWebControllersTest.IletisimBilgileriController;
using Castle.DynamicProxy;
using DAL.Models;
using HRBussiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;


namespace ArcelikLgHRWebControllersTest
{
    [TestClass]
    public class IletisimControllerTest
    {
        public static UserInformation UserInfo;
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            UserInfo = new UserInformation() { UserID = 1, TCNo = "43372950092", Name = "Barış", Surname = "Alkan", MobilePhone = "05323334455", Password = "1", Email = "baris.alkan@trinoks.com", ContractStatus = true };
        }

        private static List<ContactInformation> contactInfo;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            contactInfo = new List<ContactInformation>(){
             new ContactInformation() { ContactID = 6, HomeAddress = "New address", ProvinceOfHomeAddress = "İstanbul", TownOfHomeAddress = "Ataşehir", HomePhone = "05323334455",UserInfoId =1}
           };
        }
        [TestMethod]
        public void IletisimController_Insert()
        {   
            //Arrange
            Mock<ContactInformationRep> cRepMock = new Mock<ContactInformationRep>();
            ContactInformation cInfo = contactInfo.FirstOrDefault(Z => Z.UserInfoId == UserInfo.UserID);
            cRepMock.Setup(X => X.Insert(It.IsAny<ContactInformation>())).Callback<ContactInformation>(X => { contactInfo.Add(X); });
            Moq.Mock<IUnitOfWork> mq = new Mock<IUnitOfWork>();

            //Act
            mq.Setup(X => X.SaveChanges()).Returns(1);
            mq.Setup(X => X.ContactInformationRepository).Returns(cRepMock.Object);         

            IletisimController controller = new IletisimController(mq.Object);
            controller.ControllerContext = new ControllerContext() { HttpContext = MockHttpContext.FakeHttpContext() };
            controller.HttpContext.Session["UserInfo"] = UserInfo;

            HttpContext.Current = MockHttpContext.HttpContextCurrent();
            var res = (RedirectToRouteResult)controller.IletisimBilgileri(cInfo);
            var action = res.RouteValues["action"].Equals("MezuniyetBilgileri");

            //Assert
            Assert.IsTrue(action, "İletişim Bilgileri kaydedilemedi");
        }

        [TestMethod]
        public void IletisimController_Update()
        {
            Mock<ContactInformationRep> cRepMock = new Mock<ContactInformationRep>();
            ContactInformation cInfo = contactInfo.FirstOrDefault(Z => Z.UserInfoId == UserInfo.UserID);
            cRepMock.Setup(X => X.Update(It.IsAny<ContactInformation>()));

            Moq.Mock<IUnitOfWork> mq = new Mock<IUnitOfWork>();
            mq.Setup(X => X.SaveChanges()).Returns(1);
            mq.Setup(X => X.ContactInformationRepository).Returns(cRepMock.Object);

            IletisimController controller = new IletisimController(mq.Object);
            controller.ControllerContext = new ControllerContext() { HttpContext = MockHttpContext.FakeHttpContext() };
            controller.HttpContext.Session["UserInfo"] = UserInfo;

            var contact = new ContactInformation { HomeAddress = "New address", ProvinceOfHomeAddress = null, TownOfHomeAddress = null, HomePhone = "" };
            HttpContext.Current = MockHttpContext.HttpContextCurrent();            
        }
        [TestMethod]
        public void IletisimController_GetAll()
        {
            Mock<ContactInformationRep> cRepMock = new Mock<ContactInformationRep>();
            ContactInformation cInfo = contactInfo.FirstOrDefault(Z => Z.UserInfoId == UserInfo.UserID);
            
        }
        [TestMethod]
        public void IletisimController_NullCheckControl()
        {
            //Arrange
            Mock<ContactInformationRep> cRepMock = new Mock<ContactInformationRep>();
            cRepMock.Setup(X => X.Insert(It.IsAny<ContactInformation>())).Callback<ContactInformation>(X => { contactInfo.Add(X); });
            ContactInformation cInfo = contactInfo.FirstOrDefault(Z => Z.UserInfoId == UserInfo.UserID);
            cRepMock.Setup(X => X.FirstOrDefault(Y => Y.UserInfoId == UserInfo.UserID)).Returns(cInfo);
            cRepMock.Setup(X => X.Update(It.IsAny<ContactInformation>()));

            Moq.Mock<IUnitOfWork> mq = new Mock<IUnitOfWork>();
            mq.Setup(X => X.SaveChanges()).Returns(1);
            mq.Setup(X => X.ContactInformationRepository).Returns(cRepMock.Object);

            var expectedViewName = "MezuniyetBilgileri";
            var expectedHomeAddress = "New address";

            IletisimController controller = new IletisimController(mq.Object);
            controller.ControllerContext = new ControllerContext() { HttpContext = MockHttpContext.FakeHttpContext() };
            controller.HttpContext.Session["UserInfo"] = UserInfo;

            //var contact = new ContactInformation { HomeAddress = "New address", ProvinceOfHomeAddress = null, TownOfHomeAddress = null, HomePhone = "" };
            HttpContext.Current = MockHttpContext.HttpContextCurrent();

            //Act
            //controller.ModelState.AddModelError("HomeAddress", "Ev adresi boş geçilemez.");
            var result = controller.IletisimBilgileri(cInfo) as ViewResult;

            Assert.AreEqual(expectedHomeAddress, contactInfo.FirstOrDefault(X => X.UserInfoId == UserInfo.UserID).HomeAddress);
            //Assert.AreEqual(expectedViewName,acti);
        }

        [TestMethod]
        public void IletisimController_Valid()
        {
            //Arrange
            var contact = new ContactInformation { HomeAddress = null, ProvinceOfHomeAddress = null, TownOfHomeAddress = null, HomePhone = "" };
            var context = new ValidationContext(contact, null, null);
            var result = new List<ValidationResult>();
            //Act
            var valid = Validator.TryValidateObject(contact, context, result, true);
            //Assert
            Assert.IsFalse(valid);
        }
    }
}
