using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Models;
using System.Collections.Generic;
using HRBussiness;
using DAL;

namespace ArcelikLgHRWebTests.GirisTests
{
    [TestClass]
    public class GirisTest
    {
        public static List<UserInformation> userInfos;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            userInfos = new List<UserInformation>(){
             new UserInformation() { UserID = 1, TCNo = "43372950092", Name = "Barış", Surname = "Alkan", MobilePhone = "05323334455", Password = "123", Email = "baris.alkan@trinoks.com", ContractStatus = true },
             new UserInformation() { UserID = 2, TCNo = "41380742470", Name = "Eda", Surname = "Ekiz", MobilePhone = "05323334455", Password = "123", Email = "eda.ekiz@trinoks.com", ContractStatus = true },
             new UserInformation() { UserID = 3, TCNo = "43372950092", Name = "Sena", Surname = "Sarıyılmaz", MobilePhone = "05323334455", Password = "123", Email = "sena.sariyilmaz@trinoks.com", ContractStatus = true } };
        }


        [Owner("Eda Ekiz")]
        [Description("TC Kimlik numarası sadece rakamlardan ve 11 basamaktan oluşmalıdır. İlk hane 0 olamaz. İlk 9 basamak arasında kurulan bir algoritma bize 10. basamağı, ilk 10 basamak arasında kurulan algoritma ise bize 11. basamağı verir.")]
        [TestMethod]
        public void LoginPage_TCNoControl_IsTCNoInTheAppropriateFormat()
        {
            //Arrange
            string TCNo = "41380742470";

            //Assert
            bool actual = TCKimlikNoValidation.TCNoControl(TCNo);
            Assert.IsTrue(actual);
        }

        [Owner("Eda Ekiz")]
        [Description("Giriş sayfasında girilen T.C. kimlik numarası ve şifrenin, sistemde kayıtlı olanlarla eşleşip eşleşmediğinin konrolünü sağlar.")]
        [TestMethod]
        public void LoginPage_DoesTCNoAndPasswordMatch()
        {
            //Arrange
            string TCNo = "41380742470";
            string password = "1";
            MockObjectUserRep userMock = new MockObjectUserRep();

            //Act
            var authenticedUser = userMock.Login(TCNo, password);

            //Assert
            Assert.IsNotNull(authenticedUser, "Girmiş olduğunuz T.C. kimlik numarası veya şifre yanlış!");
        }

        //[Owner("Eda Ekiz")]
        //[Description("Kullanıcının şifresini unuttuğu zaman 'SMS Gönder' seçeneğini seçtiğinde SMS'in başarıl bir şekilde iletilip iletilmediğinin kontrolünü sağlar.")]
        //[TestMethod]
        //public void LoginPage_DoesSMSSend()
        //{
        //    //Arrange
        //    MockObjectMessageRep messageRep = new MockObjectMessageRep();
        //    string TcNo = "41380742470";

        //    //Act
        //    messageRep.SendMessage(TcNo);

        //    //Assert
        //    //Assert.IsNotNull(authenticedUser, "Girmiş olduğunuz T.C. kimlik numarası veya şifre yanlış!");
        //}

    }
}
