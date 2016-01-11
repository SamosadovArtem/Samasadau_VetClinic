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

        VetDBDataContext dataBase { get; set; }

        public SQLRepository()
        {
            dataBase = DependencyResolver.Current.GetService<VetDBDataContext>();
        }
        public IQueryable<Doctor> GetDoctors()
        {
            return dataBase.Doctor;
        }
        public bool AddSchedule(Schedule instance)
        {
            throw new NotImplementedException();
        }



        public bool AddDoctor(Doctor instance)
        {
            dataBase.Doctor.InsertOnSubmit(instance);
            dataBase.Doctor.Context.SubmitChanges();
            return true;
        }
    }
}