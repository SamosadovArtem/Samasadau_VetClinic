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
            dataBase.Schedule.InsertOnSubmit(instance);
            dataBase.Schedule.Context.SubmitChanges();
            return true;
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

        public bool AddPet(Pet instance)
        {
            dataBase.Pet.InsertOnSubmit(instance);
            dataBase.Pet.Context.SubmitChanges();
            return true;
        }

        public IQueryable<Pet> GetPets()
        {
            return dataBase.Pet;
        }

        public string GetPetNameByID(int petID)
        {
            Pet currentPet = (from p in dataBase.Pet
                              where p.ID == petID
                              select p).Single<Pet>();
            return currentPet.Name;
        }

        public IQueryable<Card> GetCardByPetID(int petID)
        {
            return (from c in dataBase.Card
                    where c.Pet == petID
                    select c);
        }

        public IQueryable<Client> GetClientByID(int ID)
        {
            return (from c in dataBase.Client
                    where c.ID == ID
                    select c);
        }

        public Doctor GetDoctorByID(int ID)
        {
            Doctor currentDoctor = (from d in dataBase.Doctor
                              where d.ID == ID
                              select d).Single<Doctor>();
            return currentDoctor;
        }

        public IQueryable<Recall> GetRecallsByDoctorID(int ID)
        {
            return (from r in dataBase.Recall
                    where r.DoctorID == ID
                    select r);
        }

        public bool AddRecall(Recall instance)
        {
            dataBase.Recall.InsertOnSubmit(instance);
            dataBase.Recall.Context.SubmitChanges();
            return true;
        }
    }
}