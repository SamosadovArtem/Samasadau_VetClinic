using System;
using System.Linq;

namespace VetClinic.Models
{
    partial class Schedule
    {
    }

    partial class DoctorRole
    {
    }

    partial class Doctor
    {



        public string ConfirmPassword { get; set; }

        //----------------------------------------
        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                bool hasRole;
                try
                {
                    hasRole = DoctorRole.Any(p => string.Compare(p.Role.Code, role, true) == 0);
                }
                catch (NullReferenceException)
                {
                    return false;
                }
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

