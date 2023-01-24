using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArcelikLgHRWeb.Controllers;
using DAL.Models;
using System.Web.Mvc;
using HRBussiness;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Moq;
using System.Linq.Expressions;
using ArcelikLgHRWebControllersTest.IletisimBilgileriController;
using System.Web;
using System.Linq;
using DAL;
using System.Data.Entity.Validation;

namespace ArcelikLgHRWebControllersTest.KisiselBilgilerController
{
    [TestClass]
    public class KisiselControllerTest
    {
        public static UserInformation UserInfo;
        private static List<PersonalInformation> personalInfo;

        [DataSource("System.Data.SqlClient", @"Data Source=TRN001\SQL2012;Initial Catalog=ARCELIKHRWEB;Persist Security Info=True;user id=sa;password=trn_09052002;Pooling=False", "PersonalInformation", DataAccessMethod.Sequential)]
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            personalInfo = new List<PersonalInformation>(){
             new PersonalInformation
            {
                PersonalID = 1,
                ModifiedDate = DateTime.Now,
                SgkNumber = "1234567891011",
                MotherName = "Test",
                FatherName = "Test",
                Gender = "Kadın",
                BirthDate = new DateTime(1994, 10, 30),
                BirthPlace = "MALATYA",
                Education = "Lise (kolej) Mezunu",
                WorkBeforeArcelikLg = false,
                Overtime = false,
                NightShift = false,
                MilitaryStatus = "Muaf",
                DefermentDate = null,
                Nationality = "ALMANYA",
                ProfessionalJob = "Bilgisayar Mühendisliği",
                IsValid = true,
                UserInfoId = 1
            }};


            UserInfo = new UserInformation() { UserID = 1, TCNo = "43372950092", Name = "Barış", Surname = "Alkan", MobilePhone = "05323334455", Password = "1", Email = "baris.alkan@trinoks.com", ContractStatus = true };
        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void KisiselController_Update()
        {
            PersonalInformationRep personalRep = new PersonalInformationRep();
            var expected = personalRep.GetById(2);
            expected.BirthDate = new DateTime(1991, 12, 12);
            expected.MotherName = "SA";
            personalRep.Update(expected);
            var actual = personalRep.GetById(expected.PersonalID);
            //Assert.IsNotNull(expected, "Bu kullanıcıya ait kişisel bilgiler bulunmakta.");
            Assert.IsInstanceOfType(expected, typeof(PersonalInformation));
            Assert.AreEqual(actual.PersonalID, expected.PersonalID);
            Assert.AreEqual(actual.MotherName, expected.MotherName);
            //Assert.AreEqual(expected.UserInfoId, newPersonal.UserInfoId);

            //Arrange
            //Mock<PersonalInformationRep> personalRepMock = new Mock<PersonalInformationRep>();
            //PersonalInformation pInfo = personalInfo.FirstOrDefault(X => X.UserInfoId == UserInfo.UserID);
            //personalRepMock.Setup(x => x.Update(It.IsAny<PersonalInformation>()));

            //Act
            //Moq.Mock<IUnitOfWork> mq = new Mock<IUnitOfWork>();
            //mq.Setup(X => X.SaveChanges()).Returns(1);
            //mq.Setup(X => X.PersonalInformationRepository).Returns(personalRepMock.Object);

            //KisiselController controller = new KisiselController(mq.Object);
            //controller.ControllerContext = new ControllerContext() { HttpContext = MockHttpContext.FakeHttpContext() };
            //controller.HttpContext.Session["UserInfo"] = UserInfo;

            //HttpContext.Current = MockHttpContext.HttpContextCurrent();
            //var res = (RedirectToRouteResult)controller.KisiselBilgiler(pInfo);
            //var action = res.RouteValues["action"].Equals("IletisimBilgileri");

            //Assert
            //Assert.IsTrue(action, "Kişisel Bilgiler kaydedilemedi");
        }
        //[DataSource("System.Data.SqlClient", @"Data Source=TRN001\SQL2012;Initial Catalog=ARCELIKHRWEB;Persist Security Info=True;user id=sa;password=trn_09052002;Pooling=False", "PersonalInformation", DataAccessMethod.Sequential)]
        [Owner("Eda Ekiz")]
        [TestMethod]
        public void KisiselController_Insert()
        {
                var newPersonal = new PersonalInformation
            {
                SgkNumber = "1234567891011",
                MotherName = "Test",
                FatherName = "Test",
                Gender = "Kadın",
                BirthDate = new DateTime(1994, 10, 30),
                BirthPlace = "İZMİR",
                Education = "Lise (kolej) Mezunu",
                WorkBeforeArcelikLg = false,
                Overtime = false,
                NightShift = false,
                MilitaryStatus = "Muaf",
                DefermentDate = null,
                Nationality = "ALMANYA",
                ProfessionalJob = "Matematik Mühendisliği",
                IsValid = true,
                UserInfoId = 26
            };

                PersonalInformationRep personalRep = new PersonalInformationRep();
                var expected = personalRep.GetById(8);
                //var result = personalRep.GetAll().Count()+1;
                personalRep.Insert(newPersonal);
                //var actual = personalRep.GetAll().Count();            
                Assert.IsNull(expected, "Bu kullanıcıya ait kişisel bilgiler bulunmakta.");
                //Assert.IsInstanceOfType(expected, typeof(PersonalInformation));
                //Assert.AreEqual(actual, expected, "Kayıt işlemi gerçekleştirilemedi.");

                var personal = personalRep.FirstOrDefault(x => x.UserInfoId == 26);
                Assert.IsNull(personal, "Bu kullanıcıya ait kişisel bilgiler bulunmakta.");
        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void KisiselController_NullCheckControl()
        {
            //Arrange
            var personal = new PersonalInformation
            {
                PersonalID = 8,
                ModifiedDate = DateTime.Now,
                SgkNumber = "1234567891011",
                MotherName = "Test",
                FatherName = "Test",
                Gender = "Kadın",
                BirthDate = new DateTime(1994, 10, 30),
                BirthPlace = "İZMİR",
                Education = "Lise (kolej) Mezunu",
                WorkBeforeArcelikLg = false,
                Overtime = false,
                NightShift = false,
                MilitaryStatus = "Muaf",
                DefermentDate = null,
                Nationality = "ALMANYA",
                ProfessionalJob = "Matematik Mühendisliği",
                IsValid = true,
                UserInfoId = 26
            };
            var context = new ValidationContext(personal, null, null);
            var result = new List<ValidationResult>();
            //Act
            var valid = Validator.TryValidateObject(personal, context, result, true);
            //Assert
            Assert.IsTrue(valid, "Lütfen zorunlu alanları doldurunuz.");
        }
    }
}
