using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using VetClinic.Models;

namespace VetClinic.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public IRepository _repository;


        public HomeController()
        {
            _repository = DependencyResolver.Current.GetService<IRepository>();
        }
        public string Index()
        {
            
            var doctors = _repository.GetDoctors().ToList();
            return doctors[0].Name;
        }

    }
}
