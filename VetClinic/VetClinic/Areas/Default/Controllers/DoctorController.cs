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
                var currentDoctor = (Doctor)_mapper.Map(newDoctor, typeof(DoctorView), typeof(Doctor));
                this.SaveClient(currentDoctor);

                if (!SendEmail(currentDoctor))
                {
                    ModelState.AddModelError("Email", "Введите корректный емейл");
                    DeleteDoctor(currentDoctor.ID);
                    return View(newDoctor);
                }


                return RedirectToAction("Confirm", "Doctor", new { doctorID = currentDoctor.ID});

            }


            return View(newDoctor);
        }

        private bool SendEmail(Doctor currentDoctor)
        {
            MailSandler mail = new MailSandler();
            return mail.SendEmail(string.Format("Для завершения регистрации перейдите по ссылке: {0}",
            Url.Action("ConfirmEmail", "Doctor", new { doctorID = currentDoctor.ID }, Request.Url.Scheme)), currentDoctor.Email);
        }

        public string Confirm(int doctorID)
        {
            return string.Format("Для завершения регистрации перейдите по ссылке:" +
                            "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                Url.Action("ConfirmEmail", "Account", new { doctorID = doctorID }, Request.Url.Scheme));
            //Doctor dc = _repository.GetDoctorByID(doctorID);
            //return Url.Action("ConfirmEmail", "Doctor", new { dc.ID }, Request.Url.Scheme);
        }

        public ActionResult ConfirmEmail(int doctorID)
        {

            _repository.DoctorConfirmEmail(doctorID);
            return View();

        }

        private void SaveClient(Doctor newDoctor)
        {
            _repository.AddDoctor(newDoctor);
        }
        private void DeleteDoctor(int doctorID)
        {
            _repository.DeleteDoctor(doctorID);
        }

    }
}
