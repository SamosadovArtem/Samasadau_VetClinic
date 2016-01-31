using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace VetClinic.Models.SQLRepository
{
    public class SQLRepository : IRepository
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

        //------------------------------
        public Doctor Login(string email, string password)
        {
            return dataBase.Doctor.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }


        public Doctor GetUser(string email)
        {
            return dataBase.Doctor.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public IQueryable<Schedule> GetSchedules()
        {
            return dataBase.Schedule;
        }

        public IQueryable<Client> GetClients()
        {
            return dataBase.Client;
        }

        public bool AddClient(Client instance)
        {
            dataBase.Client.InsertOnSubmit(instance);
            dataBase.Client.Context.SubmitChanges();
            return true;
        }
    }
}