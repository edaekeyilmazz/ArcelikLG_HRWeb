using DAL.Models;
//using hbehr.recaptcha;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArcelikLgHRWeb.Controllers
{
    public class KayitController : Controller
    {
          protected  IUnitOfWork _uow;
        public KayitController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        //private readonly UnitOfWork _uow = UnitOfWork.UnitOfWorkInstance;
        // GET: Kayit
        public ActionResult KayitIslemi()
        {
            //string publicKey = "6Ldv2DkUAAAAANlI8fIIdimTRnodWuYabY1DXklD";
            //string secretKey = "6Ldv2DkUAAAAAI7XqXdjeJBE4ZIBy3B1AigUzv8d";
            //ReCaptcha.Configure(publicKey, secretKey);
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KayitIslemi(UserInformation userInfo, string PasswordConfirm)
        {
            //string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            //bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
            //if (validCaptcha)
            //{
                var user = _uow.UserInformationRepository.FirstOrDefault(X => X.TCNo == userInfo.TCNo);
                if (user != null)
                {
                    ModelState.AddModelError("", "Bu T.C Kimlik numarası sistemde kayıtlıdır.");
                    return View(userInfo);
                }
                else
                {
                    if (ModelState.IsValid)
                    {


                        if (!userInfo.Password.Equals(PasswordConfirm))
                        {
                            ModelState.AddModelError("PasswordConfirm", "Şifreler eşleşmiyor!");
                            return View(userInfo);
                        }
                        else
                        {
                            _uow.UserInformationRepository.Insert(userInfo);
                            _uow.SaveChanges();
                            return RedirectToAction("Giris", "Anasayfa");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Anasayfa", "Giris");
                    }
                }
            //}
            //ModelState.AddModelError("ReCaptchaErr", "Geçersiz Güvenlik Bilgisi!");
            //return View(userInfo);

        }
    }
}