using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.MezuniyetControllerTests
{
    [TestClass]
    public class MezuniyetTest
    {
        public static List<GraduationInformation> graduationInfos;
        
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            graduationInfos = new List<GraduationInformation>(){
             new GraduationInformation() { HighSchoolDepartment = "a",HighSchoolDiplomaDegree = "2",HighSchoolGraduationYear = "2007",HighSchoolName = "a",HighSchoolProvince = "a", HighSchoolType = "a",DepartmentName = "a",UniversityProvince = "a",UniversityName = "a",OtherUniversityName = string.Empty,UniversityGraduationYear = "2017",UniversityDiplomaDegree = "3",MYOName = "a"}};
        }

        [TestMethod]
        [Owner("Sena Sarıyılmaz")]
        public void GraduationInformation_Insert()
        {

            //Arrange
            long graduateID = 3;
            //Act
            MockObjectGraduationRep mockGraduation = new MockObjectGraduationRep(graduationInfos);
            int newCount = graduationInfos.Count + 1;
            GraduationInformation graduate = new GraduationInformation();
            graduate.HighSchoolDepartment = "a";
            graduate.HighSchoolDiplomaDegree = "2";
            graduate.HighSchoolGraduationYear = "2007";
            graduate.HighSchoolName = "a";
            graduate.HighSchoolProvince = "a";
            graduate.HighSchoolType = "a";
            graduate.DepartmentName = "a";
            graduate.UniversityProvince = "a";
            graduate.UniversityName = "a";
            graduate.OtherUniversityName = string.Empty;
            graduate.UniversityGraduationYear = "2017";
            graduate.UniversityDiplomaDegree = "3";
            graduate.MYOName = "a";
            graduate.GraduateID = 3;
            mockGraduation.Insert(graduate);

            //Assert
            Assert.AreEqual(newCount, graduationInfos.Count);
            Assert.AreEqual(graduateID, graduate.GraduateID, "Mezuniyet Bilgileri eklenemedi.");
            Assert.IsTrue(graduate.GraduateID > 0, "Mezuniyet Bilgileri eklenemedi.");
        }
        [TestMethod]
        [Owner("Sena Sarıyılmaz")]
        public void GraduationInformation_Update()
        {
            //Arrange
            long graduateID = 3;
            long userinfoID = 3;
            //Act
            MockObjectGraduationRep mockGraduation = new MockObjectGraduationRep();
            var graduate = mockGraduation.FirstOrDefault(x => x.GraduateID == 3);
            GraduationInformation info = new GraduationInformation() { HighSchoolDepartment = "b", HighSchoolDiplomaDegree = "2", HighSchoolGraduationYear = "2007", HighSchoolName = "b", HighSchoolProvince = "b", HighSchoolType = "a", DepartmentName = "a", UniversityProvince = "a", UniversityName = "b", OtherUniversityName = string.Empty, UniversityGraduationYear = "2017", UniversityDiplomaDegree = "3", MYOName = "a", GraduateID = graduateID, UserInfoId = userinfoID };

            mockGraduation.Update(info);

            var NewGraduateInfo = mockGraduation.FirstOrDefault(X => X.GraduateID == info.GraduateID);
            //Assert
            Assert.IsNotNull(NewGraduateInfo);
            Assert.IsNotNull(info);
            Assert.ReferenceEquals(info, NewGraduateInfo);
        }
    }
}

