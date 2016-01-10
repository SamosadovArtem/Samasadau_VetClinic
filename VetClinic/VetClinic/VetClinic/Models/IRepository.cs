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
        //bool Update();
        //bool Delete();
    }
}
