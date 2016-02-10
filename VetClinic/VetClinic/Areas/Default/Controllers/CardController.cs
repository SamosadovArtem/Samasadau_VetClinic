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
        //
        // GET: /Default/Card/

        public ActionResult Index(int petID)
        {
            List<Card> card = _repository.GetCardByPetID(petID).ToList();
            return View(card);
        }

    }
}
