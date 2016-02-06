using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Models.ViewModels;
using VetClinic.Models;

namespace VetClinic.Areas.Admin.Controllers
{
    public class ClientController :  AdminController
    {
        //
        // GET: /Admin/AddToDataBase/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddClient()
        {
            ClientView newClient = new ClientView();
            return View(newClient);
        }

        [HttpPost]
        public ActionResult AddClient(ClientView newClient)
        {
            bool anyUser = _repository.GetClients().Any(p => string.Compare(p.Email, newClient.Email) == 0);
            if (anyUser)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");
                
            }

            if (ModelState.IsValid)
            {
                var currentClient = (Client)_mapper.Map(newClient, typeof(ClientView), typeof(Client));
                this.SaveClient(currentClient);
                return RedirectToAction("Index", "Success");
            }
            return View(newClient);
            // return View("~Areas/Admin/Views/Success/Index.cshtml");

        }
        private void SaveClient(Client currentClient)
        {
            _repository.AddClient(currentClient);
        }


    }
}
