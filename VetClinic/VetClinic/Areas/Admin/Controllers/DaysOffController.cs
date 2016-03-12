using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Admin.Controllers
{
    public class DaysOffController : AdminController
    {
        //
        // GET: /Admin/DaysOff/

        [HttpGet]
        public ActionResult NewDayOff()
        {
            DaysoffView newDayOff = new DaysoffView();
            return View(newDayOff);
        }

        [HttpPost]
        public ActionResult NewDayOff(DaysoffView newDayOff)
        {
            if ((Convert.ToDateTime(newDayOff.date))<=DateTime.Now)
            {
                ModelState.AddModelError("Date", "Устанавливать выходные можно только за один день до рабочего");
            }

            if (ModelState.IsValid)
            {
                var currentDayOff = (Daysoff)_mapper.Map(newDayOff, typeof(DaysoffView), typeof(Daysoff));
                //this.DeleteOldDaysOff();
                this.SaveDayOff(currentDayOff);
                return RedirectToAction("Index", "Success");

            }
            return View(newDayOff);
        }

        private void SaveDayOff(Daysoff newDayOff)
        {
            _repository.AddDayOff(newDayOff);
        }
        private void DeleteOldDaysOff()
        {
            List<Daysoff> allDaysOff = _repository.GetDaysOff().ToList();
            foreach (Daysoff dayoff in allDaysOff)
            {
                if(dayoff.Date<DateTime.Now)
                {
                    _repository.DeleteDayOff(dayoff.ID);
                }
            }
        }
    }
}
