using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Admin.Controllers
{
    public class PetController : AdminController
    {
        //
        // GET: /Admin/Pet/

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddPet()
        {
            List<Client> allClients = _repository.GetClients().ToList();
            var newPet = new PetView();
            newPet.mastersList = allClients;
            return View(newPet);
        }

        [HttpPost]
        public ActionResult AddPet(PetView newPet)
        {
            bool anyPetName = _repository.GetPets().Any(p => string.Compare(p.Name, newPet.name) == 0);
            bool anyPetMaster = _repository.GetPets().Any(p => string.Compare(p.Master.ToString(), newPet.master.ToString()) == 0);
            if (anyPetName&&anyPetMaster)
            {
                ModelState.AddModelError("Name", "Этот питомец уже зарегестрирован");
            }

            if (ModelState.IsValid)
            {
                var currentPet = (Pet)_mapper.Map(newPet, typeof(PetView), typeof(Pet));
                this.SavePet(currentPet);
                return RedirectToAction("Index", "Success");

            }
            newPet.mastersList = _repository.GetClients().ToList();
            return View(newPet);
        }

        private void SavePet(Pet currentPet)
        {
            _repository.AddPet(currentPet);
        }
    }
}
