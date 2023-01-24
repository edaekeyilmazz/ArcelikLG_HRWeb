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
    public class IletisimController : BaseController
    {
        
        public IletisimController(IUnitOfWork uow):base(uow)
        {
            _uow = uow;
        }
      
        // GET: Iletisim
        public ActionResult IletisimBilgileri()
        {
            getAll();
            var contact = _uow.ContactInformationRepository.FirstOrDefault(x => x.UserInfoId == UIHelper.UserInfo.UserID);
            if (contact != null)
            {
                return View(contact);
            }
            return View(new ContactInformation());
        }

        [HttpPost]
        public ActionResult IletisimBilgileri(ContactInformation contact)
        {
            if (ModelState.IsValid)
            {
                var contact2 = _uow.ContactInformationRepository.FirstOrDefault(x => x.UserInfoId == UIHelper.UserInfo.UserID);
                if (contact2 != null)
                {
                    contact2.HomeAddress = contact.HomeAddress;
                    contact2.HomePhone = contact.HomePhone;
                    contact2.TownOfHomeAddress = contact.TownOfHomeAddress;
                    contact2.ProvinceOfHomeAddress = contact.ProvinceOfHomeAddress;
                    _uow.ContactInformationRepository.Update(contact2);
                    if (_uow.SaveChanges() > 0)
                        return RedirectToAction(Helper.NextSteps["ContactInformation"].ActionName, Helper.NextSteps["ContactInformation"].ControllerName);
                }
                else
                {
                    contact.UserInfoId = UIHelper.UserInfo.UserID;
                    _uow.ContactInformationRepository.Insert(contact);
                    if (_uow.SaveChanges() > 0)
                        return RedirectToAction(Helper.NextSteps["ContactInformation"].ActionName, Helper.NextSteps["ContactInformation"].ControllerName);
                } 
            }
            return View(contact);
        }

        private void getAll()
        {
            if (_uow.ContactInformationRepository.Cities == null) return;
            TempData["Cities"] = _uow.ContactInformationRepository.Cities.Select((X, i) => new SelectListItem() { Text = X, Value = X }).ToList();
        }


        public JsonResult GetDistricts(string CityName)
        {
            List<string> results = _uow.ContactInformationRepository.GetDistrictsByCity(CityName);
            return Json(results.Select(x => new SelectListItem() { Value = x.Split('#')[1], Text = x.Split('#')[1] }), JsonRequestBehavior.AllowGet);
        }
    }
}