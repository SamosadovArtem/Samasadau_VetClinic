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


        public IQueryable<Pet> GetPetByMasterName(string name)
        {
            Client currentClient = GetClientByName(name);
            //Client currentClient;
            //try
            //{
            //    currentClient = GetClientByName(name).ToList()[0];
            //}
            //catch (ArgumentOutOfRangeException)
            //{
            //    return null ;
            //}
            
                return (from p in dataBase.Pet
                        where p.Master == currentClient.ID
                        select p);
        }

        public Client GetClientByName(string name)
        {
            try
            {
                return (from c in dataBase.Client
                        where c.Name == name
                        select c).Single();
            }
            catch (InvalidOperationException)
            {

                return new Client();
            }

          
        
        }

        public IQueryable<Pet> GetPetnByName(string name)
        {
            return (from p in dataBase.Pet
                    where p.Name == name
                    select p);
        }

        public IQueryable<Pet> GetPetnByKind(string kind)
        {
            return (from p in dataBase.Pet
                    where p.Kind == kind
                    select p);
        }

        public Pet GetPetByID(int ID)
        {
            return (from p in dataBase.Pet
                    where p.ID == ID
                    select p).Single();
        }

        public Schedule GetScheduleByID(int scheduleID)
        {
            return (from s in dataBase.Schedule
                    where s.ID == scheduleID
                    select s).Single();
        }

        public bool AddCard(Card instance)
        {
            dataBase.Card.InsertOnSubmit(instance);
            dataBase.Card.Context.SubmitChanges();
            return true;
        }

        public bool DeleteSchedule(Schedule instance)
        {
            dataBase.Schedule.DeleteOnSubmit(instance);
            dataBase.SubmitChanges();
            return true;
        }

        public bool IsTimeFree(DateTime date, string time)
        {
            List<Schedule> thisDate = (from s in dataBase.Schedule
                                       where s.Date == date
                                       select s).ToList();
            foreach (Schedule currentSchedule in thisDate)
            {
                if (currentSchedule.Time==time)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPetMakeAnAppOnCurrentDate(DateTime date, int petID)
        {
            List<Schedule> thisDate = (from s in dataBase.Schedule
                                       where s.Date == date
                                       select s).ToList();
            foreach (Schedule currentSchedule in thisDate)
            {
                if (currentSchedule.Pet == petID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DoctorConfirmEmail(int doctorID)
        {
            Doctor confirmDoctor = (from d in dataBase.Doctor
                                    where d.ID == doctorID
                                    select d).Single();
            confirmDoctor.ConfirmEmail = true;
            dataBase.SubmitChanges();
            return true;
        }

        public bool DeleteDoctor(int doctorID)
        {
            Doctor deleteDoctor = (from d in dataBase.Doctor
                                    where d.ID == doctorID
                                    select d).Single();
            dataBase.GetTable<Doctor>().DeleteOnSubmit(deleteDoctor);
            dataBase.SubmitChanges();
            return true;
        }

        public bool DoctorConfirmAdmin(int doctorID)
        {
            Doctor confirmDoctor = (from d in dataBase.Doctor
                                    where d.ID == doctorID
                                    select d).Single();
            confirmDoctor.ConfirmAdmin = true;
            dataBase.SubmitChanges();
            return true;
        }

        public bool ChangeSchedule(Schedule instance)
        {
            Schedule newSchedule = (from s in dataBase.Schedule
                                    where s.ID == instance.ID
                                    select s).Single();
            newSchedule.Date = instance.Date;
            newSchedule.Pet = instance.Pet;
            newSchedule.Time = instance.Time;
            dataBase.SubmitChanges();
            return true;
        }

        public IQueryable<Schedule> GetSchedulesToCurrentDoctor(int doctorID)
        {
            return (from s in dataBase.Schedule
                    where s.Doctor == doctorID
                    select s);
        }

        public IQueryable<Procedure> GetProcedures()
        {
            return dataBase.Procedure;
        }

        public bool AddProcedure(Procedure instance)
        {
            dataBase.Procedure.InsertOnSubmit(instance);
            dataBase.Procedure.Context.SubmitChanges();
            return true;
        }
    }
}