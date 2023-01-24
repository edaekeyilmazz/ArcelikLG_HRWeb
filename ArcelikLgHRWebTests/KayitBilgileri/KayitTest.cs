using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Models;
using HRBussiness;
using System.Linq.Expressions;
using ArcelikLgHRWeb.Controllers;
using System.ComponentModel.DataAnnotations;
using DAL;

namespace ArcelikLgHRWebTests.KayitBilgileri
{
    /// <summary>
    /// Summary description for KayitTest
    /// </summary>
    /// 

    [TestClass]
    public class KayitTest
    {
        public static List<UserInformation> _userInfos;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _userInfos = new List<UserInformation>(){
             new UserInformation() { UserID = 1, TCNo = "43372950092", Name = "Barış", Surname = "Alkan", MobilePhone = "05323334455", Password = "1", Email = "baris.alkan@trinoks.com", ContractStatus = true },
             new UserInformation() { UserID = 2, TCNo = "41380742470", Name = "Eda", Surname = "Ekiz", MobilePhone = "05323334455", Password = "1", Email = "eda.ekiz@trinoks.com", ContractStatus = true },
             new UserInformation() { UserID = 3, TCNo = "43372950092", Name = "Sena", Surname = "Sarıyılmaz", MobilePhone = "05323334455", Password = "1", Email = "sena.sariyilmaz@trinoks.com", ContractStatus = true } };
        }

        [Owner("Eda Ekiz")]
        [Description("TC Kimlik numarası sadece rakamlardan ve 11 basamaktan oluşmalıdır. İlk hane 0 olamaz. İlk 9 basamak arasında kurulan bir algoritma bize 10. basamağı, ilk 10 basamak arasında kurulan algoritma ise bize 11. basamağı verir.")]
        [TestMethod]
        public void TCNoControl_IsTCNoInTheAppropriateFormat()
        {
            //Arrange
            string TCNo = "41380742470";

            //Act
            bool actual = TCKimlikNoValidation.TCNoControl(TCNo);
        
            //Assert
            Assert.IsTrue(actual);
        }


        //[Owner("Eda Ekiz")]
        //[TestMethod]
        //public void UserInformation_Update()
        //{
        //    MockObjectUserRep userMock = new MockObjectUserRep(_userInfos);
        //    var user = userMock.FirstOrDefault(x => x.TCNo == "41380742470");
        //    UserInformation info = new UserInformation() { Name = "Burak", UserID = user.UserID, Email = user.Email, TCNo = "41380742470" };
        //    //Assert.IsNull(user);
        //    //user.Name = "Burak";
        //    userMock.Update(info);

        //    var NewUser = userMock.FirstOrDefault(X => X.UserID == info.UserID);

        //    Assert.ReferenceEquals(user, NewUser);
        //    Assert.AreEqual(info.Name, NewUser.Name);
        //    //Assert.IsTrue(true);
        //}


        [Owner("Eda Ekiz")]
        [TestMethod]
        public void UserInformation_Insert()
        {
            MockObjectUserRep userMock = new MockObjectUserRep(_userInfos);
            string TCNo = "11111111111111";
            int newCount = _userInfos.Count + 1;
            UserInformation userInfo = new UserInformation();

            userInfo.TCNo = TCNo;
            userInfo.Name = "Eda";
            userInfo.Surname = "Ekiz";
            userInfo.MobilePhone = "05323334455";
            userInfo.Password = "1";
            userInfo.Email = "eda.ekiz@trinoks.com";
            userInfo.ContractStatus = true;

            userMock.Insert(userInfo);

            Assert.AreEqual(newCount, _userInfos.Count, "Kullanıcı eklenemedi.");
            Assert.IsTrue(userInfo.IsValid);

        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UserInformation_Not_Insert()
        {
            MockObjectUserRep userMock = new MockObjectUserRep(_userInfos);
            string TCNo = "41380742470";
            int newCount = _userInfos.Count + 1;
            UserInformation userInfo = new UserInformation();

            userInfo.TCNo = TCNo;
            userInfo.Name = "Eda";
            userInfo.Surname = "Ekiz";
            userInfo.MobilePhone = "05323334455";
            userInfo.Password = "1";
            userInfo.Email = "eda.ekiz@trinoks.com";
            userInfo.ContractStatus = true;

            userMock.Insert(userInfo);
        }

        [Owner("Eda Ekiz")]
        [TestMethod]
        public void UserInformation_Delete()
        {
            MockObjectUserRep userMock = new MockObjectUserRep(_userInfos);
            var user = userMock.FirstOrDefault(x => x.TCNo == "41380742470");
            userMock.Delete(user);
            Assert.IsFalse(user.IsValid);
            //Assert.IsNull(user.ModifiedDate);
        }
    }
}
