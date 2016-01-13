using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using VetClinic.Models;

namespace VetClinic.Infrastructure.Auth
{
    public class DoctorIdentity : IIdentity, IProvider
    {

        public Doctor User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(Doctor).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }

    }
}