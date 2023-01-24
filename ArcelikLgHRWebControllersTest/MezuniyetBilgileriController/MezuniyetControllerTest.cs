using ArcelikLgHRWeb.Controllers;
using DAL.Models;
using HRBussiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArcelikLgHRWebControllersTest.MezuniyetBilgileriController
{
    [TestClass]
    public class MezuniyetControllerTest
    {
        UnitOfWork uow = new UnitOfWork();
        [TestMethod]
        public void GraduationInformation_NullCheckControl()
        {
            var expectedViewName = "MezuniyetBilgileri";
            var graduate = new GraduationInformation(); //{ DepartmentName = null, HighSchoolDepartment = null, HighSchoolDiplomaDegree = null, HighSchoolGraduationYear = null, HighSchoolName = null, MYOName = null, HighSchoolProvince = null, HighSchoolType = null, OtherUniversityName = null, UniversityDiplomaDegree = null, UniversityGraduationYear = null, UniversityName = null, UniversityProvince = null };
            MezuniyetController controller = new MezuniyetController(uow);
            controller.ModelState.AddModelError("HighSchoolName", "Lise adı boş geçilemez.");
            var result = controller.MezuniyetBilgileri(graduate) as ViewResult;
            Assert.IsNull(result);
            Assert.AreEqual(expectedViewName, result.ViewName);
        }
        [TestMethod]
        public void GraduationInformation_Valid()
        {
            var graduate = new GraduationInformation() { DepartmentName = null, HighSchoolDepartment = null, HighSchoolDiplomaDegree = null, HighSchoolGraduationYear = null, HighSchoolName = null, MYOName = null, HighSchoolProvince = null, HighSchoolType = null, OtherUniversityName = null, UniversityDiplomaDegree = null, UniversityGraduationYear = null, UniversityName = null, UniversityProvince = null };
            var context = new ValidationContext(graduate, null, null);
            var result = new List<ValidationResult>();
            //Act
            var valid = Validator.TryValidateObject(graduate, context, result, true);
            //Assert
            Assert.IsFalse(valid);
        }
    }
}
