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
    public class KisiselController : BaseController
    {
     
        public KisiselController(IUnitOfWork uow):base(uow)
        {
            _uow = uow;
        }
        // GET: Kisisel
        public async Task<ActionResult> KisiselBilgiler()
        {
            await Task.Run(() => getAllAsync());
            var personal = _uow.PersonalInformationRepository.FirstOrDefault(X => X.UserInfoId == UIHelper.UserInfo.UserID);
            if (personal != null)
            {
                return View(personal);
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KisiselBilgiler(PersonalInformation personalInfo)
        {
            if (ModelState.IsValid)
            {
                var personal = _uow.PersonalInformationRepository.FirstOrDefault(X => X.UserInfoId == UIHelper.UserInfo.UserID);
                if (personal != null)
                {
                    personal.SgkNumber = personalInfo.SgkNumber;
                    personal.MotherName = personalInfo.MotherName;
                    personal.FatherName = personalInfo.FatherName;
                    personal.BirthPlace = personalInfo.BirthPlace;
                    personal.BirthDate = personalInfo.BirthDate;
                    personal.Gender = personalInfo.Gender;
                    personal.Education = personalInfo.Education;
                    personal.Overtime = personalInfo.Overtime;
                    personal.NightShift = personalInfo.NightShift;
                    personal.WorkBeforeArcelikLg = personalInfo.WorkBeforeArcelikLg;
                    personal.MilitaryStatus = personalInfo.MilitaryStatus;
                    personal.DefermentDate = personalInfo.DefermentDate;
                    personal.Nationality = personalInfo.Nationality;
                    personal.ProfessionalJob = personalInfo.ProfessionalJob;
                    _uow.PersonalInformationRepository.Update(personal);
                    if (_uow.SaveChanges() > 0)
                        return RedirectToAction(Helper.NextSteps["PersonalInformation"].ActionName, Helper.NextSteps["PersonalInformation"].ControllerName);
                }
                else
                {
                    personalInfo.UserInfoId = UIHelper.UserInfo.UserID;
                    _uow.PersonalInformationRepository.Insert(personalInfo);
                    if (_uow.SaveChanges() > 0)
                        return RedirectToAction(Helper.NextSteps["PersonalInformation"].ActionName, Helper.NextSteps["PersonalInformation"].ControllerName);
                }
            }

            return View("KisiselBilgiler", personalInfo);
        }

        private async void getAllAsync()
        {
            var pi = _uow.PersonalInformationRepository;
            List<Task<List<string>>> tasks = new List<Task<List<string>>>();
            tasks.Add(Task<List<string>>.Run(() => pi.Cities));
            tasks.Add(Task<List<string>>.Run(() => pi.Genders));
            tasks.Add(Task<List<string>>.Run(() => pi.EducationInformations));
            tasks.Add(Task<List<string>>.Run(() => pi.MilitaryInformations));
            tasks.Add(Task<List<string>>.Run(() => pi.BloodTypes));
            tasks.Add(Task<List<string>>.Run(() => pi.DisablityReasons));
            tasks.Add(Task<List<string>>.Run(() => pi.Nationalities));
            tasks.Add(Task<List<string>>.Run(() => pi.HealthStatus));
            tasks.Add(Task<List<string>>.Run(() => pi.JobList));
            await Task.WhenAll(tasks);
            TempData["BirthPlace"] = tasks[0].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["Gender"] = tasks[1].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["Education"] = tasks[2].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["MilitaryStatus"] = tasks[3].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["BloodType"] = tasks[4].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            List<SelectListItem> yesNoQuestion = new List<SelectListItem>();
            yesNoQuestion.Add(new SelectListItem { Text = "Evet", Value = bool.TrueString });
            yesNoQuestion.Add(new SelectListItem { Text = "Hayır", Value = bool.FalseString });
            TempData["YesNoQuestion"] = yesNoQuestion;
            TempData["ExemptReason"] = tasks[5].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["Nationality"] = tasks[6].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["HealthStatus"] = tasks[7].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
            TempData["ProfessionalJob"] = tasks[8].Result.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
        }
    }
}