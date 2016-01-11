using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetClinic.Mappers;
using VetClinic.Models;

namespace VetClinic.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected IRepository _repository;
        protected IMapper _mapper;

        public BaseController()
        {
            _repository = DependencyResolver.Current.GetService<IRepository>();
            _mapper = DependencyResolver.Current.GetService<IMapper>();
        }


    }
}
