using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetClinic.Areas.Default.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Default/Error/

        public ActionResult Index()
        {
            return View();
        }

    }
}
