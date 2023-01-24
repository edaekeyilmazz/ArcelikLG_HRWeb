using ArcelikLgHRWeb.Controllers;
using ArcelikLgHRWebControllersTest.IletisimBilgileriController;
using DAL.Models;
using HRBussiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace ArcelikLgHRWebControllersTest.KayitBilgileriController
{
    [TestClass]
    public class KayitControllerTest
    {
        public static List<UserInformation> userInfos;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            userInfos = new List<UserInformation>(){
             new UserInformation() { UserID = 1, TCNo = "43372950092", Name = "Barış", Surname = "Alkan", MobilePhone = "05323334455", Password = "1", Email = "baris.alkan@trinoks.com", ContractStatus = true },
             new UserInformation() { UserID = 2, TCNo = "41380742470", Name = "Eda", Surname = "Ekiz", MobilePhone = "05323334455", Password = "1", Email = "eda.ekiz@trinoks.com", ContractStatus = true },
             new UserInformation() { UserID = 3, TCNo = "43372950092", Name = "Sena", Surname = "Sarıyılmaz", MobilePhone = "05323334455", Password = "1", Email = "sena.sariyilmaz@trinoks.com", ContractStatus = true } };
        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void KayitController_Insert()
        {
            //Arrange
            var newRegister = new UserInformation
            {
                TCNo = "23012151836",
                Name = "Burak",
                Surname = "Akbal",
                MobilePhone = "05323334455",
                Password = "1",
                Email = "burak.akbal@trinoks.com",
                ContractStatus = true
            };
            UnitOfWork uow = new UnitOfWork();

            //Act
            var expected=uow.UserInformationRepository.FirstOrDefault(x => x.TCNo == newRegister.TCNo);
            Assert.IsNull(expected, "Bu kullanıcı sistemde kayıtlı.");

            var expectedCount = uow.UserInformationRepository.GetAll().Count() + 1;
            uow.UserInformationRepository.Insert(newRegister);
 
            //bool result = uow.SaveChanges() > 0;
            //bool result = (uow.SaveChanges() > 0);
            int result = uow.SaveChanges();
            //if (uow.SaveChanges() > 0) result = true;
            var registerControl = uow.UserInformationRepository.GetById(newRegister.UserID);
            var actualCount = uow.UserInformationRepository.GetAll().Count();


            //Act
            Assert.AreEqual(1, result);// .IsTrue(result, "Kayıt gerçekleştirilemedi.");
            Assert.AreEqual(newRegister.Name, registerControl.Name);
            Assert.IsNull(expected, "Bu kullanıcıya ait kişisel bilgiler bulunmakta.");
            Assert.AreEqual(actualCount, expectedCount, "Kayıt işlemi gerçekleştirilemedi.");

        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void KayitController_NullCheckControl()
        {
            //Arrange
            var user = new UserInformation
            {
                UserID = 1,
                TCNo = "43372950092",
                Name = "Sena",
                Surname = "Sarıyılmaz",
                MobilePhone = "05323334455",
                Password = "1",
                Email = "sena.sariyilmaz@trinoks.com",
                ContractStatus = true
            };
            var context = new ValidationContext(user, null, null);
            var result = new List<ValidationResult>();

            //Act
            var valid = Validator.TryValidateObject(user, context, result, true);

            //Assert
            Assert.IsTrue(valid, "Lütfen zorunlu alanları doldurunuz.");
        }
    }
}
