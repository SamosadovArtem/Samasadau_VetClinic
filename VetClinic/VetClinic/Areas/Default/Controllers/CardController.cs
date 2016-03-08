using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models.ViewModels;
using System.Collections.Generic;
using VetClinic.Controllers;
using VetClinic.Models;

namespace VetClinic.Areas.Default.Controllers
{
    public class CardController : BaseController
    {
        public int Shedule { get; private set; }

        //
        // GET: /Default/Card/

        public ActionResult Index(int petID)
        {
            List<Card> card = _repository.GetCardByPetID(petID).ToList();
            return View(card);
        }

        public ActionResult SelectPetToEntry()
        {
            List<ScheduleView> currentSchedule = GetPetsToNewEntry();
            return View(currentSchedule);
        }

        private List<ScheduleView> GetPetsToNewEntry()
        {
            List<ScheduleView> currentSchedule = new List<ScheduleView>();
            List<Schedule> allSchedule = _repository.GetSchedules().ToList();
            foreach (Schedule schedule in allSchedule)
            {
                if ((schedule.Date.Day <= DateTime.Today.Day) && (CurrentUser.ID == schedule.Doctor))
                {
                    ScheduleView tempScheduleView = (ScheduleView)_mapper.Map(schedule, typeof(Schedule), typeof(ScheduleView));
                    tempScheduleView.DateToDisplay = Convert.ToDateTime(tempScheduleView.date);
                    tempScheduleView.PetName = _repository.GetPetNameByID(schedule.Pet);
                    currentSchedule.Add(tempScheduleView);
                }
            }
            return currentSchedule;
        }

        [HttpGet]
        public ActionResult AddNewEntry(int scheduleID)
        {
            Schedule currentSchedule = _repository.GetScheduleByID(scheduleID);
            return View(currentSchedule);
        }
        [HttpPost]
        public ActionResult AddNewEntry(string cardText, int scheduleID)
        {
            Schedule currentSchedule = _repository.GetScheduleByID(scheduleID);
            Card newCard = FillCard(currentSchedule, cardText);
            SaveCard(newCard);
            DeleteSchedule(currentSchedule);

            return RedirectToAction("SelectPetToEntry", "Card");
        }
        private Card FillCard (Schedule currentSchedule, string cardText)
        {
            Card newCard = new Card();
            newCard.Date = currentSchedule.Date;
            newCard.Disease = cardText;
            newCard.Pet = currentSchedule.Pet;
            return newCard;
        }
        private void SaveCard(Card newCard)
        {
            _repository.AddCard(newCard);
        }
        private void DeleteSchedule(Schedule oldScedule)
        {
            _repository.DeleteSchedule(oldScedule);
        }
    }
}
