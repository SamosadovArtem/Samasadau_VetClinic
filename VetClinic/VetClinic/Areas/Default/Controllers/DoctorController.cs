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
    public class DoctorController : BaseController
    {
        //
        // GET: /Doctor/

        //public IRepository _repository;

        public DoctorController()
        {
            //_repository = DependencyResolver.Current.GetService<IRepository>();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            DoctorView doctor = new DoctorView();
            return View(doctor);
        }

        [HttpPost]
        public ActionResult Register(DoctorView doctor)
        {
            bool anyUser = _repository.GetDoctors().Any(p => string.Compare(p.Email, doctor.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
            }

            if (ModelState.IsValid)
            {
                var currentDoctor =(Doctor)_mapper.Map(doctor, typeof(DoctorView),typeof(Doctor));
                //TODO : Save
                this.SaveDoctor(currentDoctor);
                

            }

            return View(doctor);
        }

        private void SaveDoctor(VetClinic.Models.Doctor newDoctor)
        {
            _repository.AddDoctor(newDoctor);
        }

    }
}
