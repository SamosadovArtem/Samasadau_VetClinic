using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Controllers;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/Admin/
        


    }
}
