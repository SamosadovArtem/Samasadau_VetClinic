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
    public class RecallController : BaseController
    {
        //
        // GET: /Default/Recall/


        [HttpGet]
        public ActionResult ChooseDoctor()
        {
            List<Doctor> allDoctors = _repository.GetDoctors().ToList();
            return View(allDoctors);
        }
        [HttpPost]
        public ActionResult ChooseDoctor(int doctorID, string action)
        {
            if (action == "Watch")
            {
                return RedirectToAction("GetRecalls", "Recall", new { currentDoctor = doctorID });
            }
            else if (action == "Add")
            {
                return RedirectToAction("SetRecalls", "Recall", new { currentDoctor = doctorID });
            }
            else
            {
                throw new Exception("No action");
            }


        }

        public ActionResult GetRecalls(int currentDoctor)
        {
            List<Recall> currentRecalls = _repository.GetRecallsByDoctorID(currentDoctor).ToList();
            ViewBag.DoctorName = _repository.GetDoctorByID(currentDoctor).Name;
            return View(currentRecalls);
        }
        [HttpGet]
        public ActionResult SetRecalls(int currentDoctor)
        {
            RecallView newRecall = new RecallView();
            newRecall.DoctorID = currentDoctor;
            newRecall.Date = DateTime.Now;
            ViewBag.DoctorName = _repository.GetDoctorByID(currentDoctor).Name;
            return View(newRecall);
        }
        [HttpPost]
        public ActionResult SetRecalls(RecallView newRecall)
        {
            var currentRecall = (Recall)_mapper.Map(newRecall, typeof(RecallView), typeof(Recall));
            SaveRecall(currentRecall);
            return RedirectToAction("GetRecalls", "Recall", new { currentDoctor = currentRecall.DoctorID});
        }

        public void SaveRecall(Recall currentRecall)
        {
            _repository.AddRecall(currentRecall);
        }

    }
}
