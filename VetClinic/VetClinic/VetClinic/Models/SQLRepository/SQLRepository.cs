using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace VetClinic.Models.SQLRepository
{
    public class SQLRepository:IRepository
    {

        VetDBDataContext db { get; set; }

        public SQLRepository()
        {
            db = DependencyResolver.Current.GetService<VetDBDataContext>();
        }
        public IQueryable<Doctor> GetDoctors()
        {
            return db.Doctor;
        }
        public bool AddSchedule(Schedule instance)
        {
            throw new NotImplementedException();
        }

    }
}