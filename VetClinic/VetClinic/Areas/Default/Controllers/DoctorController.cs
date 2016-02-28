using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VetClinic.Controllers;
using VetClinic.Infrastructure.Mail;
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
            DoctorView newDoctor = new DoctorView();
            return View(newDoctor);
        }

        [HttpPost]
        public ActionResult Register(DoctorView newDoctor)
        {
            bool anyUser = _repository.GetDoctors().Any(p => string.Compare(p.Email, newDoctor.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
            }

            if (ModelState.IsValid)
            {
                var currentDoctor =(Doctor)_mapper.Map(newDoctor, typeof(DoctorView),typeof(Doctor));
                //TODO : Save
                this.SaveClient(currentDoctor);
                MailSandler mail = new MailSandler();
                //mail.SendEmail(string.Format("Для завершения регистрации перейдите по ссылке: " +
                //            "<a href=\"{0}\">Подтверждение</a>",
                //Url.Action("ConfirmEmail", "Doctor", new { Doctor = newDoctor })));
                return RedirectToAction("Confirm", "Doctor", new { doctorID = currentDoctor.ID});

            }


            return View(newDoctor);
        }

        public string Confirm(int doctorID)
        {
            //return "Выслано письмо";
            Doctor dc = _repository.GetDoctorByID(doctorID);
            return Url.Action("ConfirmEmail", "Doctor", new { dc.ID });
        }

        public ActionResult ConfirmEmail()//int doctorID
        {

            //Doctor user =  newDoctor;
            //if (doctorID != null)
            {
                Doctor currentDoctor = _repository.GetDoctorByID(1010);//doctorID
                currentDoctor.ConfirmEmail = true;
                return RedirectToAction("Index", "Home");
            }
           // else
            {
                return RedirectToAction("Confirm", "Doctor");
            }

        }

        private void SaveClient(Doctor newDoctor)
        {
            _repository.AddDoctor(newDoctor);
        }

    }
}
