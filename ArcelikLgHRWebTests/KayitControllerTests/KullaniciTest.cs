using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.KayitControllerTests
{
    public class KullaniciTest
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
        public void UserInformation_Update()
        {
            MockObjectUserRep userMock = new MockObjectUserRep(userInfos);
            var user = userMock.FirstOrDefault(x => x.TCNo == "41380742470");
            UserInformation info = new UserInformation() { Name = "Burak", UserID = user.UserID, Email = user.Email, TCNo = "41380742470" };
            //Assert.IsNull(user);
            //user.Name = "Burak";
            userMock.Update(info);

            var NewUser = userMock.FirstOrDefault(X => X.UserID == info.UserID);

            Assert.ReferenceEquals(user, NewUser);
            Assert.AreEqual(info.Name, NewUser.Name);
            //Assert.IsTrue(true);
        }


    }
}
