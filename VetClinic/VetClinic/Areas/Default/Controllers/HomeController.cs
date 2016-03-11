using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using VetClinic.Controllers;
using VetClinic.Models;
using VetClinic.Infrastructure;
using System.Net.Mail;
using System.Net;

namespace VetClinic.Areas.Default.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        
        //public IRepository _repository;


        public HomeController()
        {
            //_repository = DependencyResolver.Current.GetService<IRepository>();
        }
        public ActionResult Index()
        {




            //var doctors = _repository.GetDoctors().ToList();
            //DateWork monthInfo = new DateWork();
            //monthInfo.GenerateDaysInfo(_repository.GetSchedules().ToList());

            //Month currentMonth = new Month();
            Month currentMonth;
            //currentMonth.GenerateDaysInfo(_repository.GetSchedules().ToList());
            //List<Day> ld = currentMonth.days;


            if (CurrentUser != null)
            {
                ViewBag.CurrentID = CurrentUser.ID;
                currentMonth = GetCurrentSchedule(CurrentUser.ID);
            }
            else
            {
                ViewBag.CurrentID = 0;
                currentMonth = GetCurrentSchedule(0);
            }
            // List<Doctor> doctors = new List<Doctor>();
            //doctors.Add(new Doctor());
            
            return View(currentMonth);
            //return DateWork.GetFirstDayOfMonthName();
            //return doctors[0].Name;
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

        private Month GetCurrentSchedule(int doctorID)
        {
            Month currentMonth = new Month();
            List<Schedule> currentSchedule = _repository.GetSchedulesToCurrentDoctor(doctorID).ToList();
            currentMonth.GenerateDaysInfo(currentSchedule);
            return currentMonth;
        }
    }
}
