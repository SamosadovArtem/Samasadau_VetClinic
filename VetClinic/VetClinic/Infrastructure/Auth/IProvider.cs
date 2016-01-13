using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Models;

namespace VetClinic.Infrastructure.Auth
{
    interface IProvider
    {

        Doctor User { get; set; }

    }
}
