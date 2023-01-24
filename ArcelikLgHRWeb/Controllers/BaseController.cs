using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArcelikLgHRWeb.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork _uow;
        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        //protected UnitOfWork _uow;

        //public BaseController()
        //{
        //    _uow = UnitOfWork.UnitOfWorkInstance;
        //}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["stepValidation"] != null)
            {
                filterContext.Controller.ViewBag.StepValidation = (string)Session["stepValidation"];
                Session.Remove("stepValidation");
            }
            if (Session["UserInfo"] == null || (Session["UserInfo"] != null && !(Session["UserInfo"] as DAL.Models.UserInformation).IsAuthenticatedUser))
            {
                filterContext.Result = Redirect("~/Anasayfa/Giris");
            }
            else
            {
                var step = Helper.GetStepByControllerName(filterContext.Controller.GetType().Name);
                if (step != null)
                {
                    if (!_uow.UserInformationRepository.CheckStep(UIHelper.UserInfo.UserID, step.ID))
                    {
                        var nextStep = _uow.UserInformationRepository.NextStep != null ? _uow.UserInformationRepository.NextStep : _uow.UserInformationRepository.GetNextStep(UIHelper.UserInfo.UserID);

                        Session["stepValidation"] = nextStep.ControllerName + " adımını tamamlamalısınız!.";
                        filterContext.Result = Redirect(string.Format("~/{0}/{1}", nextStep.ControllerName, nextStep.ActionName));
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}