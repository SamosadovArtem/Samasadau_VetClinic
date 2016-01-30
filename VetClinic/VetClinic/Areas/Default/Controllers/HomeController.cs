using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using VetClinic.Controllers;
using VetClinic.Models;
using VetClinic.Infrastructure;

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

            var cookie = new HttpCookie("test_cokie", DateTime.Now.ToString("dd.MM.yyyy"));
 
            Response.SetCookie(cookie);

            var doctors = _repository.GetDoctors().ToList();
            DateWork monthInfo = new DateWork();
            monthInfo.GenerateDaysInfo(_repository.GetSchedules().ToList());
<<<<<<< HEAD
            if (CurrentUser != null)
            {
                ViewBag.CurrentID = CurrentUser.ID;
            }
            else
            {
                ViewBag.CurrentID = 0;
            }
            // List<Doctor> doctors = new List<Doctor>();
            //doctors.Add(new Doctor());
            
=======
            // List<Doctor> doctors = new List<Doctor>();
            //doctors.Add(new Doctor());
>>>>>>> e8145fdf8335c4f24faff27b3c379d7f7f194389
            return View(monthInfo);
            //return DateWork.GetFirstDayOfMonthName();
            //return doctors[0].Name;
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }

    }
}
