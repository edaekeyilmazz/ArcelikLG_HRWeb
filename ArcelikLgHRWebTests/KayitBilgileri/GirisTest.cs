using ArcelikLgHRWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using HRBussiness;
using DAL;
using System.ComponentModel.DataAnnotations;

namespace ArcelikLgHRWebTests.Giris
{
    [TestClass]
    public class GirisTest
    {
        public static List<UserInformation> userInfos;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            userInfos = new List<UserInformation>() {
                new UserInformation() { 
                  TCNo="41380742470",
                  Password="123",

                }};
        }

        [Owner("Eda Ekiz")]
        [Description("TC Kimlik numarası sadece rakamlardan ve 11 basamaktan oluşmalıdır. İlk hane 0 olamaz. İlk 9 basamak arasında kurulan bir algoritma bize 10. basamağı, ilk 10 basamak arasında kurulan algoritma ise bize 11. basamağı verir.")]
        [TestMethod]
        public void TCNoControl_IsTCNoInTheAppropriateFormat()
        {
            //Arrange
            string TCNo = "41380742470";

            //Act
            bool actual = DAL.Models.TCKimlikNoValidation.TCNoControl(TCNo);

            //Assert
            Assert.IsTrue(actual);
        }

        [Owner("Eda Ekiz")]
        [Description("Giriş sayfasında kullanıcının girdiği kulanıcı adı ve şifrenin eşleşip eşleşmediğinin kontrolü yapılır.")]
        [TestMethod]
        public void Login_DoesUsernameAndPasswordMatch()
        {
            MockObjectUserRep mockLogin = new MockObjectUserRep();
            string tcno = "41380742470";
            string sifre="123";
        }
    }
}
