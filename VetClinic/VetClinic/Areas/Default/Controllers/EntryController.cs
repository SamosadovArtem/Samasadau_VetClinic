using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Controllers;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Default.Controllers
{
    public class EntryController : BaseController
    {
        //
        // GET: /Default/Entry/

            [HttpGet]
        public ActionResult Index()
        {
            ScheduleView newSchedule = new ScheduleView();
            newSchedule.DoctorList = _repository.GetDoctors().ToList();
            newSchedule.PetList = _repository.GetPets().ToList();
            newSchedule.ProcedureList = _repository.GetProcedures().ToList();
            return View(newSchedule);
        }
        [HttpPost]
        public ActionResult Index(ScheduleView newSchedule)
        {
            if (IsPetMakeApp(Convert.ToDateTime(newSchedule.date), newSchedule.Pet))
            {
                ModelState.AddModelError("Title", "Питомец уже записан на выбранную дату");
            }
            if (!IsTimeFree(Convert.ToDateTime(newSchedule.date), newSchedule.Time))
            {
                ModelState.AddModelError("Time", "Время занято");
            }
            if (newSchedule.date <= DateTime.Now)
            {
                ModelState.AddModelError("Date", "Запись возможно за один день до рабочего");
            }

            if (ModelState.IsValid)
            {
                var currentSchedule = (Schedule)_mapper.Map(newSchedule, typeof(ScheduleView), typeof(Schedule));
                this.SavePet(currentSchedule);
                return RedirectToAction("Index", "Success");

            }
            newSchedule.DoctorList = _repository.GetDoctors().ToList();
            newSchedule.PetList = _repository.GetPets().ToList();
            newSchedule.ProcedureList = _repository.GetProcedures().ToList();
            return View(newSchedule);
        }

        private void SavePet(Schedule currentSchedule)
        {
            _repository.AddSchedule(currentSchedule);
        }

        private bool IsTimeFree(DateTime date, string time)
        {
            return _repository.IsTimeFree(date, time);
        }
        private bool IsPetMakeApp(DateTime date, int petID)
        {
            return _repository.IsPetMakeAnAppOnCurrentDate(date, petID);
        }
    }
}
