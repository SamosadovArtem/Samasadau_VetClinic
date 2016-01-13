using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using VetClinic.Infrastructure.Auth;
using VetClinic.Mappers;
using VetClinic.Models;

namespace VetClinic.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        [Inject]
        protected IRepository _repository;

        [Inject]
        protected IMapper _mapper;

        [Inject]
        protected IAuthentication _auth;

        public BaseController()
        {
            _repository = DependencyResolver.Current.GetService<IRepository>();
           _mapper = DependencyResolver.Current.GetService<IMapper>();
           _auth = DependencyResolver.Current.GetService<IAuthentication>();
        }

        public Doctor CurrentUser
        {
            get
            {
                return ((IProvider)_auth.CurrentUser.Identity).User;
            }
        }


    }
}
