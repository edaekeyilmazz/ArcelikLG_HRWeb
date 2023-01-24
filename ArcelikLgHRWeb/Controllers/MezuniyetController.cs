using DAL.Models;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArcelikLgHRWeb.Controllers
{
    public class MezuniyetController : BaseController
    {
        
        public MezuniyetController(IUnitOfWork uow):base(uow)
        {
            _uow = uow;
        }
        // GET: Mezuniyet     
        public async Task<ActionResult> MezuniyetBilgileri()
        {
            await Task.Run(() => getAllAsync());
            var graduate = _uow.GraduationInformationRepository.FirstOrDefault(x => x.UserInfoId == UIHelper.UserInfo.UserID);
            if (graduate != null)
            {
                return View(graduate);
            }
            return View(new GraduationInformation());
        }
        [HttpPost]
        public ActionResult MezuniyetBilgileri(GraduationInformation graduate)
        {
            if (ModelState.IsValid)
            {
                var graduationInfo = _uow.GraduationInformationRepository.FirstOrDefault(x => x.UserInfoId == UIHelper.UserInfo.UserID);
                if (graduationInfo != null)
                {
                    graduationInfo.HighSchoolType = graduate.HighSchoolType;
                    graduationInfo.HighSchoolProvince = graduate.HighSchoolProvince;
                    graduationInfo.HighSchoolName = graduate.HighSchoolName;
                    graduationInfo.HighSchoolGraduationYear = graduate.HighSchoolGraduationYear;
                    graduationInfo.HighSchoolDiplomaDegree = graduate.HighSchoolDiplomaDegree;
                    graduationInfo.HighSchoolDepartment = graduate.HighSchoolDepartment;
                    graduationInfo.MYOName = graduate.MYOName;
                    graduationInfo.OtherUniversityName = graduate.OtherUniversityName;
                    graduationInfo.UniversityDiplomaDegree = graduate.UniversityDiplomaDegree;
                    graduationInfo.UniversityGraduationYear = graduate.UniversityGraduationYear;
                    graduationInfo.UniversityName = graduate.UniversityName;
                    graduationInfo.UniversityProvince = graduate.UniversityProvince;
                    graduationInfo.DepartmentName = graduate.DepartmentName;
                    _uow.GraduationInformationRepository.Update(graduationInfo);
                    if (_uow.SaveChanges() > 0)
                        return RedirectToAction(Helper.NextSteps["GraduationInformation"].ActionName, Helper.NextSteps["GraduationInformation"].ControllerName);
                }
                else
                {
                    graduate.UserInfoId = UIHelper.UserInfo.UserID;
                    _uow.GraduationInformationRepository.Insert(graduate);
                    if (_uow.SaveChanges() > 0)
                        return RedirectToAction(Helper.NextSteps["GraduationInformation"].ActionName, Helper.NextSteps["GraduationInformation"].ControllerName);
                } 
            }
            return View(graduate);
        }

        private async void getAllAsync()
        {
            var pi = _uow.GraduationInformationRepository;
            List<Task<List<string>>> tasks = new List<Task<List<string>>>();
            tasks.Add(Task<List<string>>.Run(() => pi.Cities));
            tasks.Add(Task<List<string>>.Run(() => pi.HighSchoolTypes));
            tasks.Add(Task<List<string>>.Run(() => pi.Universities));
            tasks.Add(Task<List<string>>.Run(() => pi.Cities));
            tasks.Add(Task<List<string>>.Run(() => pi.GraduateYears));
            tasks.Add(Task<List<string>>.Run(() => pi.Faculties));
            tasks.Add(Task<List<string>>.Run(() => pi.Faculties));

            await Task.WhenAll(tasks);
            TempData["HighSchoolProvince"] = tasks[0].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["HighSchoolType"] = tasks[1].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["UniversityName"] = tasks[2].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["UniversityProvince"] = tasks[3].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["Years"] = tasks[4].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X}).ToList();
            TempData["MYOName"] = tasks[5].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["DepartmentName"] = tasks[6].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();

        }
    }
}