using DAL.Models;
using HRBussiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.KisiselTests
{
    [TestClass]
    public class KisiselIntegrationTest
    {
        [Owner("Eda Ekiz")]
        [TestMethod]
        public void Kisisel_Insert_IntegrationTest()
        {
            //Arrange
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
                Nationality = "ALMANYA",
                ProfessionalJob = "AVUKAT",
                IsValid = true,
                UserInfoId = 26                
            };
            
            UnitOfWork uow = new UnitOfWork();

            //Act
            var expected = uow.PersonalInformationRepository.FirstOrDefault(x => x.UserInfoId == newPersonal.UserInfoId);
            Assert.IsNull(expected, "Bu kullanıcı sistemde kayıtlı.");

            var expectedCount = uow.PersonalInformationRepository.GetAll().Count() + 1;
            uow.PersonalInformationRepository.Insert(newPersonal);

            //bool result = uow.SaveChanges() > 0;
            //bool result = (uow.SaveChanges() > 0);
            int result = uow.SaveChanges();
            //if (uow.SaveChanges() > 0) result = true;
            var registerControl = uow.PersonalInformationRepository.GetById(newPersonal.UserInfoId);
            var actualCount = uow.PersonalInformationRepository.GetAll().Count();


            //Act
            Assert.AreEqual(1, result);// .IsTrue(result, "Kayıt gerçekleştirilemedi.");
            Assert.AreEqual(newPersonal.MotherName, registerControl.MotherName);
            Assert.IsNull(expected, "Bu kullanıcıya ait kişisel bilgi bulunmakta.");
            Assert.AreEqual(actualCount, expectedCount, "Kişisel bilgi eklenemedi.");
        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void Kisisel_Update_IntegrationTest()
        {

        }
    }
}
