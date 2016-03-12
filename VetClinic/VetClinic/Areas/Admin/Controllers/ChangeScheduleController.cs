using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Admin.Controllers
{
    public class ChangeScheduleController : AdminController
    {
        //
        // GET: /Admin/ChangeSchedule/

        public ActionResult GetSchedules()
        {
            List<ScheduleView> changeableSchedule = GetScheduleToChange();
            return View(changeableSchedule);
        }

        private List<ScheduleView> GetScheduleToChange()
        {
            List<Schedule> allSchedule = _repository.GetSchedules().ToList();
            List<ScheduleView> changeableSchedule = new List<ScheduleView>();

            foreach (Schedule schedule in allSchedule)
            {
                if(schedule.Date>DateTime.Now)
                {
                    ScheduleView tempSchedule = (ScheduleView)_mapper.Map(schedule, typeof(Schedule), typeof(ScheduleView));
                    tempSchedule.DateToDisplay = Convert.ToDateTime(tempSchedule.date);
                    tempSchedule.PetName = _repository.GetPetNameByID(tempSchedule.Pet);
                    changeableSchedule.Add(tempSchedule);

                }
            }
            return changeableSchedule;
        }


        [HttpGet]
        public  ActionResult Change (int scheduleID)
        {
            Schedule currentSchedule = _repository.GetScheduleByID(scheduleID);
            ScheduleView tempSchedule = (ScheduleView)_mapper.Map(currentSchedule, typeof(Schedule), typeof(ScheduleView));
            tempSchedule.ID = scheduleID;
            tempSchedule.date = DateTime.Now;
            tempSchedule.PetList = _repository.GetPets().ToList();
            return View(tempSchedule);
        }
        [HttpPost]
        public ActionResult Change(ScheduleView newSchedule)
        {
            DateTime emptyDT = new DateTime();
            bool validFlag = true;
            if (IsPetMakeApp(Convert.ToDateTime(newSchedule.date), newSchedule.Pet))
            {
                ModelState.AddModelError("Title", "Питомец уже записан на выбранную дату");
                validFlag = false;
            }
            if (!IsTimeFree(Convert.ToDateTime(newSchedule.date), newSchedule.Time))
            {
                ModelState.AddModelError("Time", "Время занято");
                validFlag = false;
            }
            if (newSchedule.date <= DateTime.Now)
            {
                ModelState.AddModelError("Date", "Запись возможно за один день до рабочего");
                validFlag = false;
            }
            if (newSchedule.date == emptyDT)
            {
                ModelState.AddModelError("Date", "Выберете новую дату");
                validFlag = false;
            }
            if (IsDayOff(Convert.ToDateTime(newSchedule.date)))
            {
                ModelState.AddModelError("Date", "Нельзя записаться на выходной день");
                validFlag = false;
            }

            if (validFlag)
            {
                var currentSchedule = (Schedule)_mapper.Map(newSchedule, typeof(ScheduleView), typeof(Schedule));
                this.ChangeSchedule(currentSchedule);
                return RedirectToAction("Index", "Success");

            }
            newSchedule.DoctorList = _repository.GetDoctors().ToList();
            newSchedule.PetList = _repository.GetPets().ToList();
            return View(newSchedule);
        }

        private void ChangeSchedule(Schedule currentSchedule)
        {
            _repository.ChangeSchedule(currentSchedule);
        }

        private bool IsTimeFree(DateTime date, string time)
        {
            return _repository.IsTimeFree(date, time);
        }
        private bool IsPetMakeApp(DateTime date, int petID)
        {
            return _repository.IsPetMakeAnAppOnCurrentDate(date, petID);
        }

        private bool IsDayOff(DateTime date)
        {
            List<Daysoff> allDaysOff = _repository.GetDaysOff().ToList();
            foreach (Daysoff dayoff in allDaysOff)
            {
                if ((dayoff.Date == date) || (date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
