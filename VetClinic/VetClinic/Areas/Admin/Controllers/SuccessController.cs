using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetClinic.Areas.Admin.Controllers
{
    public class SuccessController : AdminController
    {
        //
        // GET: /Admin/Success/

        public ActionResult Index()
        {
            return View();
        }

    }
}
