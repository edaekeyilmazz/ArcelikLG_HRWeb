using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArcelikLgHRWeb.Controllers;
using DAL.Models;
using System.ComponentModel.DataAnnotations;
using HRBussiness;

namespace ArcelikLgHRWebTests.IletisimControllerTests
{
    /// <summary>
    /// Summary description for IletisimTest
    /// </summary>
    [TestClass]
    public class IletisimTest
    {


        public static List<ContactInformation> contactInfo;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            contactInfo = new List<ContactInformation>(){
             new ContactInformation() { ContactID = 1, HomeAddress = "Adres1", ProvinceOfHomeAddress = "İstanbul", TownOfHomeAddress = "Ataşehir", HomePhone = "05323334455",UserInfoId =1},
             new ContactInformation() {  ContactID = 2, HomeAddress = "Adres2", ProvinceOfHomeAddress = "İstanbul", TownOfHomeAddress = "Kadıköy", HomePhone = "05323334485",UserInfoId =3 }};
        } 

        [TestMethod]
        [Owner("Sena Sarıyılmaz")]
        public void ContactInformation_InsertControl()
        {
            //Arrange
            long userinfoID = 3;
            //Act
            MockObjectContactRep contactMock = new MockObjectContactRep(contactInfo);
            int newCount = contactInfo.Count + 1;
            ContactInformation contact = new ContactInformation();
            contact.UserInfoId = 3;
            contact.ContactID = 3;
            contact.HomeAddress = "K.Bakkalköy";
            contact.HomePhone = string.Empty;
            contact.ProvinceOfHomeAddress = "İstanbul";
            contact.TownOfHomeAddress = "Ataşehir";
            contactMock.Insert(contact);
            //Assert
            Assert.AreEqual(newCount, contactInfo.Count,"İletişim bilgileri eklenemedi.");
            Assert.AreEqual(userinfoID, contact.UserInfoId, "İletişim bilgileri eklenemedi.");
            Assert.IsTrue(contact.ContactID > 0, "İletişim bilgileri eklenemedi.");

        }

        [TestMethod]
        [Owner("Sena Sarıyılmaz")]
        public void ContactInformation_UpdateControl()
        {
            //Arrange
            long userinfoID = 3;
            //Act
            MockObjectContactRep contactMock = new MockObjectContactRep();
            var contact = contactMock.FirstOrDefault(x => x.UserInfoId == 3);
            ContactInformation info = new ContactInformation() { HomeAddress = "Adres3", ProvinceOfHomeAddress = "Trabzon", TownOfHomeAddress = "Ortahisar", HomePhone = string.Empty, ContactID = 3, UserInfoId = userinfoID };
            contactMock.Update(info);

            var NewContactInfo = contactMock.FirstOrDefault(X => X.ContactID == info.ContactID);
            //Assert
            Assert.IsNotNull(info);
            Assert.IsNotNull(NewContactInfo);
            Assert.ReferenceEquals(contact, NewContactInfo);      
        }
    }
}
