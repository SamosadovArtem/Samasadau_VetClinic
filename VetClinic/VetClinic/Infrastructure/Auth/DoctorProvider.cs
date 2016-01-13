using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using VetClinic.Models;

namespace VetClinic.Infrastructure.Auth
{
    public class DoctorProvider : IPrincipal
    {

        private DoctorIdentity doctorIdentity { get; set; }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return doctorIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (doctorIdentity.User == null)
            {
                return false;
            }
            return doctorIdentity.User.InRoles(role);
        }

        #endregion

        
        public DoctorProvider(string name, IRepository repository)
        {
            doctorIdentity = new DoctorIdentity();
            doctorIdentity.Init(name, repository);
        }


        public override string ToString()
        {
            return doctorIdentity.Name;
        }


    }
}