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

            var doctors = _repository.GetDoctors().ToList();
            DateWork monthInfo = new DateWork();
            monthInfo.GenerateDaysInfo(_repository.GetSchedules().ToList());
            // List<Doctor> doctors = new List<Doctor>();
            //doctors.Add(new Doctor());
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
