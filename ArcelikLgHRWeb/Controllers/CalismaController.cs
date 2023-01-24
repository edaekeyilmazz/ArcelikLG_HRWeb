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
    public class CalismaController : BaseController
    {
        
        public CalismaController(IUnitOfWork uow):base(uow)
        {
            _uow = uow;
        }
        // GET: Calisma
        public ActionResult CalismaBilgileri()
        {
            getAllFields();
            var work = _uow.WorkInformationRepository.FirstOrDefaultAsNotracking(x => x.UserInfoId == UIHelper.UserInfo.UserID, "WorkExperience");
            if (work != null)
            {
                int count = 0;
                if (work.WorkExperience == null) { count = 0; work.WorkExperience = new List<WorkExperience>(); }
                else count = 3 - work.WorkExperience.Count;

                for (int i = 0; i < count; i++)
                    work.WorkExperience.Add(new WorkExperience() { WorkID = work.WorkID });
            }
            else
            {
                work = new WorkInformation() { FireDateOfLastJob = null, IsStillWorking = null };
                work.WorkExperience.Add(new WorkExperience());
                work.WorkExperience.Add(new WorkExperience());
                work.WorkExperience.Add(new WorkExperience());
            }

            return View(work);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CalismaBilgileri(WorkInformation work)
        {
            var workRes = _uow.WorkInformationRepository.FirstOrDefault(X => X.UserInfoId == UIHelper.UserInfo.UserID, "WorkExperience");
            work.WorkExperience = work.WorkExperience.Where(X => !string.IsNullOrEmpty(X.WorkPlaceName)).ToList();
            if(workRes!=null)
            {
                workRes.IsStillWorking = work.IsStillWorking;
                workRes.FireDateOfLastJob = work.FireDateOfLastJob;
                updateDetails(workRes.WorkExperience, work.WorkExperience.ToList());
                _uow.WorkInformationRepository.Update(workRes);
            }
            else
            {
                //work.UserInformation = UIHelper.UserInfo;
                work.UserInfoId = UIHelper.UserInfo.UserID;
                List<WorkExperience> lst = work.WorkExperience.ToList();
                lst.RemoveAll(X => string.IsNullOrEmpty(X.WorkPlaceName));
                work.WorkExperience = lst;
               _uow.WorkInformationRepository.Insert(work);
            }

            if (_uow.SaveChanges() > 0)
                return RedirectToAction(Helper.NextSteps["WorkInformation"].ActionName, Helper.NextSteps["WorkInformation"].ControllerName);
            return View(work);
        }

        private void updateDetails(ICollection<WorkExperience> mainDetail, List<WorkExperience> subDetail)
        {
            List<WorkExperience> lst = new List<WorkExperience>();
            foreach (var item in mainDetail)
            {
                var res = subDetail.FirstOrDefault(X => X.WorkExperienceID == item.WorkExperienceID);
                if (res == null) lst.Add(item);
            }
            _uow.WorkInformationRepository.deleteDetails(lst.Where(X => X.WorkExperienceID > 0).ToList());
            lst.Clear();
            foreach (var item in subDetail)
            {
                var res = mainDetail.FirstOrDefault(X => X.WorkExperienceID == item.WorkExperienceID);
                if (res != null)
                {
                    res.BeginDateToWork = item.BeginDateToWork;
                    res.EndDateToWork = item.EndDateToWork;
                    res.FireReasonFromLastJob = item.FireReasonFromLastJob;
                    res.Position = item.Position;
                    res.WorkPlaceName = item.WorkPlaceName;
                }
                else
                    lst.Add(item);
            }
            lst.ForEach(X => mainDetail.Add(X));
        }
        private void getAllFields()
        {
            List<SelectListItem> yesNoQuestion = new List<SelectListItem>();
            yesNoQuestion.Add(new SelectListItem { Text = "Evet", Value = bool.TrueString });
            yesNoQuestion.Add(new SelectListItem { Text = "Hayır", Value = bool.FalseString });
            TempData["YesNoQuestion"] = yesNoQuestion;
            var beginYear = _uow.WorkInformationRepository.Years;
            TempData["BeginDateToWork"] = beginYear.Select(X => new SelectListItem() { Text = X, Value = X }).ToList();
            var endYear = _uow.WorkInformationRepository.Years;
            TempData["EndDateToWork"] = endYear.Select(X => new SelectListItem() { Text = X, Value = X }).ToList();
        }
    }
}