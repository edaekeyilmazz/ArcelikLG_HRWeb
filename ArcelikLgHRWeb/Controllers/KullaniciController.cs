using DAL.Models;
using DAL;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace ArcelikLgHRWeb.Controllers
{
    public class KullaniciController : BaseController
    {
        
        public KullaniciController(IUnitOfWork uow):base(uow)
        {
            _uow = uow;
        }
        // GET: Kullanici
        public ActionResult KullaniciBilgileri()
        {
            return View(UIHelper.UserInfo);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KullaniciBilgileri(UserInformation userInfo, string PasswordConfirm)
        {
            var user = _uow.UserInformationRepository.FirstOrDefault(X => X.TCNo == userInfo.TCNo);

            if (ModelState.IsValid)
            {
                if (!userInfo.Password.Equals(PasswordConfirm))
                {
                    ModelState.AddModelError("PasswordConfirm", "Şifreler eşleşmiyor!");
                    return View(UIHelper.UserInfo);
                }
                else if (user != null)  
                {
                    user.TCNo = userInfo.TCNo;
                    user.Name = userInfo.Name;
                    user.Surname = userInfo.Surname;
                    user.Password = userInfo.Password;
                    user.Email = userInfo.Email;
                    user.MobilePhone = userInfo.MobilePhone;
                    _uow.UserInformationRepository.Update(user);
                    if (_uow.SaveChanges() > 0)
                    {
                        UIHelper.UserInfo = user;
                        return RedirectToAction(Helper.NextSteps["UserInformation"].ActionName, Helper.NextSteps["UserInformation"].ControllerName);
                    }
                }

            }
            return View(UIHelper.UserInfo);
        }
    }
}