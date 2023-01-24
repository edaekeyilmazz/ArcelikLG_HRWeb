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

    public class TalepEdilenIslerController : BaseController
    {
        
        public TalepEdilenIslerController(IUnitOfWork uow):base(uow)
        {
            _uow =uow;
        }
        // GET: TalepEdilenIsler
        public ActionResult TalepEdilenIsler()
        {
            getAllFields();
            var job = _uow.JobInformationRepository.FirstOrDefault(x => x.UserInfoId == UIHelper.UserInfo.UserID);
            if (job != null)
            {
                return View(job);
            }
            return View();
        }
        [HttpPost]
        public ActionResult TalepEdilenIsler(JobInformation job)
        {
                var jobs = _uow.JobInformationRepository.FirstOrDefault(x => x.UserInfoId == UIHelper.UserInfo.UserID);
                if (jobs != null)
                {
                    jobs.RequestedJob1 = job.RequestedJob1;
                    jobs.RequestedJob2 = job.RequestedJob2;
                    jobs.RequestedJob3 = job.RequestedJob3;
                    _uow.JobInformationRepository.Update(jobs);
                    _uow.SaveChanges();
                    
                }
                else
                {
                    job.UserInfoId = UIHelper.UserInfo.UserID;
                    _uow.JobInformationRepository.Insert(job);
                    try
                    {
                        Step step = Helper.Steps["JobInformation"];
                        //_uow.StepRepository.User = UIHelper.UserInfo;
                        _uow.StepRepository.Insert(step);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        _uow.SaveChanges();
                    }
                }
                return RedirectToAction(Helper.NextSteps[typeof(DAL.Models.JobInformation).Name].ActionName, Helper.NextSteps[typeof(JobInformation).Name].ControllerName);
        }
        private void getAllFields()
        {
            var job = _uow.JobInformationRepository.RequestedJobs;
            TempData["Job1"] = job.Select(X => new SelectListItem() { Text = X, Value = X}).ToList();
        }
    }
}