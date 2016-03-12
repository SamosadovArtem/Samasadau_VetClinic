using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Areas.Admin.Controllers;
using VetClinic.Models;

namespace VetClinic.Areas.Admin.Controllers
{
    public class DeliveryController : AdminController
    {
        //
        // GET: /Admin/Delivery/

        [HttpGet]
        public ActionResult SetEmailText()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetEmailText(string emailText)
        {
            if (string.IsNullOrEmpty(emailText))
            {
                ModelState.AddModelError("emailText", "Введите текст рассылки");
            }
            if (ModelState.IsValid)
            {
                List<Doctor> currentDoctors = GetCurrentDoctors();
                _mail.MakeDeliver(currentDoctors, emailText);
                return RedirectToAction("Index", "Success");
            }
            return View();
        }

        private List<Doctor> GetCurrentDoctors()
        {
            List<Doctor> allDoctors = _repository.GetDoctors().ToList();
            List<Doctor> currentDoctors = new List<Doctor>();
            foreach (Doctor doctor in allDoctors)
            {
                if ((doctor.ConfirmEmail==true)&&(doctor.ConfirmAdmin==true))
                {
                    currentDoctors.Add(doctor);
                }

            }
            return currentDoctors;

        }
    }
}
