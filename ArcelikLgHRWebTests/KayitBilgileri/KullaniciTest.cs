using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Models;
using System.Collections.Generic;

namespace ArcelikLgHRWebTests.KayitBilgileri
{
    [TestClass]
    public class KullaniciTest
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
        [Description("Kullanıcı bilgilerinin güncellenme işleminin doğru bir şekilde gerçekleşip gerçekleşmediğinin kontrolünün yapıldığı testtir.")]
        [TestMethod]
        public void UserInformation_Update()
        {
            MockObjectUserRep userMock = new MockObjectUserRep(_userInfos);
            //var user = userMock.FirstOrDefault(x => x.TCNo == "41380742470");
            UserInformation info = new UserInformation() { Name = "Burak", UserID=2};
            userMock.Update(info);

            var NewUser = userMock.FirstOrDefault(X => X.UserID == info.UserID);

            Assert.ReferenceEquals(info, NewUser);
            Assert.AreEqual(info.Name, NewUser.Name, "Güncelleme işlemi gerçekleştirilemedi.");
        }
    }
}
