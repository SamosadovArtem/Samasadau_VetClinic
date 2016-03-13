using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Admin.Controllers
{
    public class SearchController : AdminController
    {
        //
        // GET: /Admin/Search/

        //private List<Pet> currentPets;

        [HttpGet]
        public ActionResult GetPets(List<Pet> petList)
        {
            //if (ViewBag.Pets == null)
            //{
            //List<Pet> currentPets = _repository.GetPets().ToList();
            //return View(currentPets);
            // }
            // else { return View(ViewBag.Pets); }
            if (petList==null)
            {
                petList = _repository.GetPets().ToList();

            }

            List<PetView> currentPets = PetToPetViewChanger(petList);
            return View(currentPets);
        }
        [HttpPost]
        public ActionResult GetPets(string searchAttribute, string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                ModelState.AddModelError("searchValue", "Заполните поле");
                List<Pet> allPets = _repository.GetPets().ToList();
                List<PetView> currentPets = PetToPetViewChanger(allPets);
                return View(currentPets);
            }
            else
            {
                switch(searchAttribute)
                {
                    case "master": return GetPetsByMaster(searchValue);

                    case "name": return GetPetsByName(searchValue);
                  
                    case "kind": return GetPetsByKind(searchValue);
                      
                    default: throw new Exception();
                }
                throw new Exception();
            }

        }

        private ActionResult GetPetsByKind(string kind)
        {
            List<Pet> currentPets = _repository.GetPetnByKind(kind).ToList();
            return GetPets(currentPets);
        }

        private ActionResult GetPetsByName(string name)
        {
            List<Pet> currentPets = _repository.GetPetnByName(name).ToList();
            return GetPets(currentPets);
        }

        public ActionResult GetPetsByMaster(string masterName)
        {
            List<Pet> currentPets = _repository.GetPetByMasterName(masterName).ToList();
            return GetPets(currentPets);
        }

        private List<PetView> PetToPetViewChanger(List<Pet> petsForChange)
        {
            List<PetView> currentPets = new List<PetView>();
            for (int i = 0;i<petsForChange.Count;i++)
            {
                
                var tempPet = (PetView)_mapper.Map(petsForChange[i], typeof(Pet), typeof(PetView));
                tempPet.masterName = _repository.GetClientByID(tempPet.master).ToList()[0].Name;
                currentPets.Add(tempPet);
            }
            return currentPets;
        }

    }
}
