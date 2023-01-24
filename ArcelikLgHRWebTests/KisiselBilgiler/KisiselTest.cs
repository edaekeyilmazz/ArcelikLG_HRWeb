using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.KisiselBilgiler
{
    [TestClass]
    public class KisiselTest
    {

        public static List<PersonalInformation> personalInfos;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            personalInfos = new List<PersonalInformation>() {
                new PersonalInformation() { 
                   PersonalID=1,
                   ModifiedDate = DateTime.Now,
                   SgkNumber = "1234567891011",
                   MotherName = "Test",
                   FatherName = "Test",
                   Gender = "Kadın",
                   BirthDate = new DateTime(1994,10,30),
                   BirthPlace = "MALATYA",
                   Education = "Lise (kolej) Mezunu",
                   WorkBeforeArcelikLg = false,
                   Overtime = false,
                   NightShift = false,
                   MilitaryStatus = "Muaf",
                   DefermentDate = null,
                   Nationality = "ALMANYA",
                   ProfessionalJob = "Bilgisayar Mühendisliği",
                   IsValid=true,
                   UserInfoId=1
                }};
        }

        [Owner("Eda Ekiz")]
        [Description("Kullanıcının kayıt işleminin doğru bir şekilde gerçekleştirilip gerçekleştirilmediğini kontrol eden testtir.")]
        [TestMethod]
        public void PersonalInformation_Insert()
        {
            //Act
            MockObjectPersonalRep personalMock = new MockObjectPersonalRep(personalInfos);
            int newCount = personalInfos.Count + 1;
            PersonalInformation personalInfo = new PersonalInformation();

            //Arrange
            personalInfo.PersonalID = personalInfos.Count;
            personalInfo.ModifiedDate = DateTime.Now;
            personalInfo.SgkNumber = "1234567891011";
            personalInfo.MotherName = "Test";
            personalInfo.FatherName = "Test";
            personalInfo.Gender = "Kadın";
            personalInfo.BirthDate = new DateTime(1994, 10, 30);
            personalInfo.BirthPlace = "MALATYA";
            personalInfo.Education = "Lise (kolej) Mezunu";
            personalInfo.WorkBeforeArcelikLg = false;
            personalInfo.Overtime = false;
            personalInfo.NightShift = false;
            personalInfo.MilitaryStatus = "Muaf";
            personalInfo.Nationality = "ALMANYA";
            personalInfo.ProfessionalJob = "Bilgisayar Mühendisliği";
            personalInfo.IsValid = true;
            personalInfo.UserInfoId = newCount;

            personalMock.Insert(personalInfo);

            //Assert
            Assert.AreEqual(newCount, personalInfos.Count, "Kayıt işlemi gerçekleştirilemedi.");
            Assert.IsTrue(personalInfo.IsValid);

        }

        [Owner("Eda Ekiz")]
        [Description("Kullanıcıya ait kişisel bilgilerin güncellenme işleminin doğru bir şekilde gerçekleşip gerçekleşmediğinin kontrolünün yapıldığı testtir.")]
        [TestMethod]
        public void PersonalInformation_Update()
        {
            //Act
            MockObjectPersonalRep personalMock = new MockObjectPersonalRep(personalInfos);
            var personal = personalMock.FirstOrDefault(x => x.UserInfoId == 1);
            PersonalInformation personalInfo = new PersonalInformation()
            {
                PersonalID = personal.PersonalID,
                ModifiedDate = DateTime.Now,
                SgkNumber = "1234567891020",
                MotherName = personal.MotherName,
                FatherName = personal.FatherName = "Test",
                Gender = personal.Gender,
                BirthDate = personal.BirthDate,
                BirthPlace = personal.BirthPlace,
                Education = personal.Education,
                WorkBeforeArcelikLg = personal.WorkBeforeArcelikLg,
                Overtime = personal.Overtime,
                NightShift = personal.NightShift,
                MilitaryStatus = personal.MilitaryStatus,
                Nationality = personal.Nationality,
                ProfessionalJob = personal.ProfessionalJob,
                IsValid = personal.IsValid,
                UserInfoId=personal.UserInfoId
            };

            //Arrange
            personalMock.Update(personalInfo);
            var NewPersonal = personalMock.FirstOrDefault(X => X.UserInfoId == personalInfo.UserInfoId);

            //Assert
            Assert.ReferenceEquals(personal, NewPersonal);
            Assert.AreEqual(personalInfo.SgkNumber, NewPersonal.SgkNumber);
        }

    }
}
