using DAL.Models;
//using hbehr.recaptcha;
using HRBussiness;
using HRMessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ArcelikLgHRWeb.Controllers
{
    public class AnasayfaController : Controller
    {
        private IUnitOfWork _uow;
        public AnasayfaController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Anasayfa
        [HttpGet]
        public ActionResult Giris()
        {
            //string publicKey = "6Ldv2DkUAAAAANlI8fIIdimTRnodWuYabY1DXklD";
            //string secretKey = "6Ldv2DkUAAAAAI7XqXdjeJBE4ZIBy3B1AigUzv8d";
            //ReCaptcha.Configure(publicKey, secretKey);
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Giris(Models.LoginViewModel lgView)
        {
            //string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            //bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
            //if (validCaptcha)
            //{
                if (ModelState.IsValid)
                {
                    var result = _uow.UserInformationRepository.Login(lgView.TCNo, lgView.Password);
                    if (result == null)
                    {
                        ModelState.AddModelError("UserAuth", "Kullanıcı adı veya şifre yanlış!");
                        return View(lgView);
                    }
                    UIHelper.UserInfo = result;
                    var step = _uow.UserInformationRepository.GetNextStep(result.UserID);

                    return RedirectToAction(step.ActionName, step.ControllerName);
                }
                //return View(lgView);
            //}
            Thread.Sleep(3000);
            //ModelState.AddModelError("ReCaptchaErr", "Geçersiz Güvenlik Bilgisi!");
            return View(lgView);
        }
        public ActionResult KayitBasarili()
        {
            return View();
        }

        public ActionResult Cikis()
        {
            HttpContext.Session.Abandon();
            return RedirectToAction("Giris", "Anasayfa");
        }
        [HttpGet]
        public ActionResult SMSGonder()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SMSGonder(string tcKimlikNo)
        {
            IMessageService smsService = new SMSMessageService();
            smsService.SendMessage(tcKimlikNo.Trim());
            return View();
        }
        public ActionResult EmailGonder(string tcKimlikNo) 
        {
            IMessageService mailService = new MailMessageService();
            mailService.SendMessage(tcKimlikNo.Trim());
            return View();
        }
    }
}