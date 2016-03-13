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
            
        }
        public ActionResult Index()
        {



            Month currentMonth;


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
          
            return View(currentMonth);

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

        public ActionResult Help()
        {



            return View();
        }

        public ActionResult MethodForRuslan()
        {
            Doctor newAdmin;
            Role newRole;
            if (!IsHaveAdmin_MethotForRuslan())
            {
                newAdmin = new Doctor();
                newAdmin.Email = "admin@admin.admin";
                newAdmin.Password = PasswordHasher.GetHashPassword("123");
                newAdmin.Name = "Admin";
                newAdmin.ConfirmAdmin = true;
                newAdmin.ConfirmEmail = true;
                _repository.AddDoctor(newAdmin);
                FillDataBase();
            }

            if (!IsHaveRoles_MethodForRuslan())
            {
                newRole = new Role();
                newRole.Name = "Admin";
                newRole.Code = "Admin";
                _repository.AddRole(newRole);
            }

            Doctor currentDoctor = _repository.GetDoctorByName("Admin");
            Role currentRole = _repository.GetRoleByName("Admin");
            _repository.MakeAdmin(currentDoctor.ID, currentRole.ID);
            return View();
        }
        private bool IsHaveAdmin_MethotForRuslan()
        {
            List<Doctor> allDoctor = _repository.GetDoctors().ToList();
            foreach (Doctor doctor in allDoctor)
            {
                if ((doctor.Email=="admin@admin.admin")&&(PasswordHasher.GetHashPassword("123")==doctor.Password))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsHaveRoles_MethodForRuslan()
        {
            List<Role> allRoles = _repository.GetRoles().ToList();
            foreach (Role role in allRoles)
            {
                if ((role.Name == "Admin") && (role.Code=="Admin"))
                {
                    return true;
                }
            }
            return false;
        }

        private void FillDataBase()
        {
            
            Client firstClient = new Client();
            firstClient.Name = "Митрон П.Е.";
            firstClient.Email = "Mitron@mail.ru";

            _repository.AddClient(firstClient);

            firstClient = _repository.GetClientByName(firstClient.Name);


            Pet firstPet = new Pet();
            firstPet.Name = "Шарик";
            firstPet.Kind = "Собака";
            firstPet.Master = firstClient.ID;
            _repository.AddPet(firstPet);

            Pet secondPet = new Pet();
            secondPet.Name = "Борис";
            secondPet.Kind = "Кот";
            secondPet.Master = firstClient.ID;
            _repository.AddPet(secondPet);

            Doctor firstDoctor = new Doctor();
            firstDoctor = new Doctor();
            firstDoctor.Email = "1@1.1";
            firstDoctor.Password = PasswordHasher.GetHashPassword("123");
            firstDoctor.Name = "Викторов П.М.";
            firstDoctor.ConfirmAdmin = true;
            firstDoctor.ConfirmEmail = true;
            _repository.AddDoctor(firstDoctor);


            Procedure firstProcedure = new Procedure();
            firstProcedure.Title = "Прививка";
            firstProcedure.Cost = 15000;
            _repository.AddProcedure(firstProcedure);

            Schedule firstSchedule = new Schedule();
            firstSchedule.Date = DateTime.Now.AddDays(1).Date;
            firstSchedule.Doctor = _repository.GetDoctorByName("Викторов П.М.").ID;
            firstSchedule.Pet = _repository.GetPetnByName("Борис").ToList()[0].ID;
            //firstSchedule.Procedure = 1;
            firstSchedule.Title = "Плановый прием";
            firstSchedule.Text = "Сделать прививку";
            firstSchedule.Time = "10:30";
            _repository.AddSchedule(firstSchedule);




        }


    }
}
