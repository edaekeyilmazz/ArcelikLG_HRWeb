using DAL.Models;
using HRBussiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.KayitControllerTests
{
    [TestClass]
    public class KayitIntegrationTest
    {
        public static UserInformation newRegister;

        [DataSource("System.Data.SqlClient", @"Data Source=TRN001\SQL2012;Initial Catalog=ARCELIKHRWEB;Persist Security Info=True;user id=sa;password=trn_09052002;Pooling=False", "PersonalInformation", DataAccessMethod.Sequential)]
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            newRegister = new UserInformation
            {
                TCNo = "23012151836",
                Name = "Burak",
                Surname = "Akbal",
                MobilePhone = "05323334455",
                Password = "1",
                Email = "burak.akbal@trinoks.com",
                ContractStatus = true
            };
        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void Kayit_Insert_IntegrationTest()
        {
            //Arrange
        
            UnitOfWork uow = new UnitOfWork();

            //Act
            var expected = uow.UserInformationRepository.FirstOrDefault(x => x.TCNo == newRegister.TCNo);
            Assert.IsNull(expected, "Bu kullanıcı sistemde kayıtlı.");

            var expectedCount = uow.UserInformationRepository.GetAll().Count() + 1;
            uow.UserInformationRepository.Insert(newRegister);

            //bool result = uow.SaveChanges() > 0;
            bool result = (uow.SaveChanges() > 0);
            //int result = uow.SaveChanges();
            var registerControl = uow.UserInformationRepository.GetById(newRegister.UserID);
            var actualCount = uow.UserInformationRepository.GetAll().Count();


            //Act
            Assert.IsTrue(result);// .IsTrue(result, "Kayıt gerçekleştirilemedi.");
            Assert.AreEqual(newRegister.Name, registerControl.Name);
            Assert.IsNull(expected, "Bu kullanıcıya ait kişisel bilgiler bulunmakta.");
            Assert.AreEqual(actualCount, expectedCount, "Kayıt işlemi gerçekleştirilemedi.");
        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void Kayit_Update_IntegrationTest()
        {
            //Arrange

            UnitOfWork uow = new UnitOfWork();

            //Act
            var expected = uow.UserInformationRepository.FirstOrDefault(x => x.TCNo == "41380742470");
            Assert.IsNotNull(expected, "Sistemde kayıtlı olmayan bir kullanıcıyı güncelleyemezsiniz.");


            newRegister.Name = "Sena";
            newRegister.Surname = "Sarıyılmaz";
            uow.UserInformationRepository.Update(newRegister);

            //bool result = uow.SaveChanges() > 0;
            bool result = (uow.SaveChanges() > 0);
            //int result = uow.SaveChanges();
            var registerControl = uow.UserInformationRepository.GetById(newRegister.UserID);


            //Act
            Assert.IsTrue(result);// .IsTrue(result, "Kayıt gerçekleştirilemedi.");
            Assert.AreEqual(newRegister.Name, registerControl.Name);
            Assert.IsNull(expected, "Bu kullanıcıya ait kişisel bilgiler bulunmakta.");
        }
    }
}
