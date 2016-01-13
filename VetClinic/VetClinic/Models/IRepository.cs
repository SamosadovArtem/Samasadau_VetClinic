using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Models
{
    public interface IRepository
    {
        IQueryable<Doctor> GetDoctors();
        bool AddSchedule(Schedule instance);
        bool AddDoctor(Doctor instance);
        //bool Update();
        //bool Delete();



        //--------------------

        Doctor Login(string email, string password);
        Doctor GetUser(string email);

        //--------------------

    }
}
