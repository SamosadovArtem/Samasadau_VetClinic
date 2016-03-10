using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Controllers;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Admin.Controllers
{
    public class ConfirmController : AdminController
    {
        //
        // GET: /Admin/Confirm/

        public ActionResult DoctorConfirm()
        {
            List<DoctorView> doctorsToConfirm = GetDoctorsToConfirm();
            return View(doctorsToConfirm);
        }

        private List<DoctorView> GetDoctorsToConfirm()
        {
            List<DoctorView> doctorsToConfirm = new List<DoctorView>();
            List<Doctor> allDoctors = _repository.GetDoctors().ToList();
           foreach (Doctor doctor in allDoctors)
            {
                if (((doctor.ConfirmAdmin== null)||(doctor.ConfirmAdmin==false))&&(doctor.ConfirmEmail==true))
                {
                    DoctorView tempDoctor = (DoctorView)_mapper.Map(doctor, typeof(Doctor), typeof(DoctorView));
                    doctorsToConfirm.Add(tempDoctor);
                }
            }
            return doctorsToConfirm;
        }
        public ActionResult Result(int doctorID, string status)
        {
            if (status == "Add")
            {
                AddDoctor(doctorID);
            }
            else if (status == "Delete")
            {
                DeleteDoctor(doctorID);
            }
            return RedirectToAction("DoctorConfirm");
        }

        private void AddDoctor(int doctorID)
        {
            _repository.DoctorConfirmAdmin(doctorID);
        }
        private void DeleteDoctor(int doctorID)
        {
            _repository.DeleteDoctor(doctorID);
        }
    }
}
