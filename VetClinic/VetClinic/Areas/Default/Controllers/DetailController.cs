using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Controllers;
using VetClinic.Infrastructure;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Default.Controllers
{
    public class DetailController : BaseController
    {
        //
        // GET: /Default/Detail/

            [HttpGet]
        public ActionResult GetPet()
        {

            Month currentMonth = new Month();
            currentMonth.GenerateDaysInfo(_repository.GetSchedulesToCurrentDoctor(CurrentUser.ID).ToList());

            if (CurrentUser != null)
            {
                ViewBag.CurrentID = CurrentUser.ID;
            }
            else
            {
                ViewBag.CurrentID = 0;
            }
            List<PetView> allPets = GetCurrentPet();
            return View(allPets);
        }

        public ActionResult Result (int userPetID)
        {
            return RedirectToAction("Index", "Card", new { petID = userPetID });
        }

        private List<PetView> GetCurrentPet()
        {
            List<Schedule> allSchedule = _repository.GetSchedules().ToList();
            List<Pet> currentPets = new List<Pet>();
            foreach(Schedule schedule in allSchedule)
            {
                Pet tempPet = _repository.GetPetByID(schedule.Pet);
                if ((schedule.Date>DateTime.Now)&&(schedule.Doctor==CurrentUser.ID)&&!IsPetAlreadyInList(currentPets, tempPet))
                {
                    currentPets.Add(tempPet);
                }
            }
            return PetToPetViewMapper(currentPets);

        }

        private bool IsPetAlreadyInList(List<Pet> petList, Pet currentPet)
        {
            foreach (Pet pet in petList)
            {
                if (pet.ID==currentPet.ID)
                {
                    return true;
                }
            }
            return false;
        }
        private List<PetView> PetToPetViewMapper(List<Pet> currentPets)
        {
            List<PetView> allPets = new List<PetView>();
            foreach (Pet pet in currentPets)
            {
                PetView tempPet = (PetView)_mapper.Map(pet, typeof(Pet), typeof(PetView));
                allPets.Add(tempPet);
            }
            return allPets;
        }
    }
}
