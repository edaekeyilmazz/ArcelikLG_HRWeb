using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRBussiness;
using DAL.Models;
using System.Collections.Generic;
using ArcelikLgHRWeb.Controllers;
using Moq;
using System.Web.Mvc;
using ArcelikLgHRWebControllersTest.IletisimBilgileriController;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DAL;

namespace ArcelikLgHRWebControllersTest.KullaniciBilgileriController
{
    [TestClass]
    public class KullaniciControllerTest
    {
        public static List<UserInformation> userInfos;
     
        [DataSource("System.Data.SqlClient", @"Data Source=TRN001\SQL2012;Initial Catalog=ARCELIKHRWEB;Persist Security Info=True;user id=sa;password=trn_09052002;Pooling=False", "PersonalInformation", DataAccessMethod.Sequential)]
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
        public void KullaniciController_Update()
        {
            //Arrange
            UnitOfWork uow = new UnitOfWork();

            //Act
            var expectedUser = uow.UserInformationRepository.FirstOrDefault(x => x.TCNo == "41380742470");
            Assert.IsNotNull(expectedUser, "Böyle bir kullanıcı bulunmadığı için güncelleştirme işlemi yapamazsınız.");

            expectedUser.Password = "2";
            expectedUser.MobilePhone = "05440000000";

            uow.UserInformationRepository.Update(expectedUser);
            bool result = false;
            if (uow.SaveChanges() > 0) result = true;
            var registerControl = uow.UserInformationRepository.GetById(expectedUser.UserID);


            //Act
            Assert.IsTrue(result, "Kayıt gerçekleştirilemedi.");
            Assert.AreEqual(expectedUser.Name, registerControl.Name);
        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void KullaniciController_NullCheckControl()
        {
            //Arrange
            var user = new UserInformation { 
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
