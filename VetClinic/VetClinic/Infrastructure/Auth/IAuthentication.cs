using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VetClinic.Models;

namespace VetClinic.Infrastructure.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        Doctor Login(string login, string password, bool isPersistent);

        Doctor Login(string login);

        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}
