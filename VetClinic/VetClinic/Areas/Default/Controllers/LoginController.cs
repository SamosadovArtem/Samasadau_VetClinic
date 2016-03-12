using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Controllers;
using VetClinic.Infrastructure;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Default.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Default/Login/

        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                string hashPassword = GetHashPassword(loginView.Password);
                var user = _auth.Login(loginView.Email, hashPassword, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                    
                }
                ModelState["Password"].Errors.Add("Пароли не совпадают");
            }
            return View(loginView);
        }

        public ActionResult Logout()
        {
            _auth.LogOut();
            return RedirectToAction("Index", "Home");
        }
        private string GetHashPassword (string password)
        {
            return PasswordHasher.GetHashPassword(password);
        }

    }
}
