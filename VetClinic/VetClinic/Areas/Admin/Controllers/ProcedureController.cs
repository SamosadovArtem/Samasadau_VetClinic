using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Admin.Controllers
{
    public class ProcedureController : AdminController
    {
        //
        // GET: /Admin/Procedure/

        [HttpGet]
        public ActionResult AddProcedure()
        {
            ProcedureView newProcedure = new ProcedureView();
            return View(newProcedure);
        }

        [HttpPost]
        public ActionResult AddProcedure(ProcedureView newProcedure)
        {
            bool anyProcedureTitle = _repository.GetProcedures().Any(p => string.Compare(p.Title, newProcedure.Title) == 0);
            if (anyProcedureTitle)
            {
                ModelState.AddModelError("Title", "Данная процедура уже зарегестрирована");
            }
            if (newProcedure.Cost<=0)
            {
                ModelState.AddModelError("Cost", "Введите корректную стоимость");
            }

            if (ModelState.IsValid)
            {
                var currentProcedure = (Procedure)_mapper.Map(newProcedure, typeof(ProcedureView), typeof(Procedure));
                this.SaveProcedure(currentProcedure);
                return RedirectToAction("Index", "Success");

            }
            return View(newProcedure);
        }

        private void SaveProcedure(Procedure currentProcedure)
        {
            _repository.AddProcedure(currentProcedure);
        }
    }
}
