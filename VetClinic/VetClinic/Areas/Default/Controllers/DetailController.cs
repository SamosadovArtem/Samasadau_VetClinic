using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Controllers;
using VetClinic.Infrastructure;
using VetClinic.Models;

namespace VetClinic.Areas.Default.Controllers
{
    public class DetailController : BaseController
    {
        //
        // GET: /Default/Detail/

            [HttpGet]
        public ActionResult Index()
        {

            Month currentMonth = new Month();
            currentMonth.GenerateDaysInfo(_repository.GetSchedules().ToList());
            List<Day> ld = currentMonth.days;
            if (CurrentUser != null)
            {
                ViewBag.CurrentID = CurrentUser.ID;
            }
            else
            {
                ViewBag.CurrentID = 0;
            }
            return View(currentMonth);
        }
        [HttpPost]
        public ActionResult Index(int userPetID)
        {
            return RedirectToAction("Index", "Card", new {petID = userPetID });

        }


    }
}
