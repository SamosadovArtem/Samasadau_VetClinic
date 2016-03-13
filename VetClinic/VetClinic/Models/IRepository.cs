using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Models.ViewModels;

namespace VetClinic.Models
{
    public interface IRepository
    {
        IQueryable<Doctor> GetDoctors();
        IQueryable<Client> GetClients();
        IQueryable<Schedule> GetSchedules();
        IQueryable<Pet> GetPets();
        bool AddSchedule(Schedule instance);
        bool AddDoctor(Doctor instance);
        bool AddClient(Client instance);
        bool AddPet(Pet instance);
        string GetPetNameByID(int petID);
        IQueryable<Card> GetCardByPetID(int petID);
        //bool Update();
        //bool Delete();
        IQueryable<Client> GetClientByID(int ID);
        Doctor GetDoctorByID(int ID);
        IQueryable<Recall> GetRecallsByDoctorID(int ID);
        bool AddRecall(Recall instance);
        IQueryable<Pet> GetPetByMasterName(string name);
        Client GetClientByName(string name);
        IQueryable<Pet> GetPetnByName(string name);
        IQueryable<Pet> GetPetnByKind(string kind);
        Pet GetPetByID(int ID);
        Schedule GetScheduleByID(int scheduleID);
        bool AddCard(Card instance);
        bool DeleteSchedule(Schedule instance);
        bool IsTimeFree(DateTime date, string time);
        bool AddDayOff(Daysoff instance);
        bool IsPetMakeAnAppOnCurrentDate(DateTime date, int petID);
        IQueryable<Daysoff> GetDaysOff();
        bool AddProcedure(Procedure instance);


        //--------------------

        Doctor Login(string email, string password);
        bool DeleteDayOff(int dayoffID);
        Doctor GetUser(string email);
        bool DoctorConfirmEmail(int doctorID);
        bool DeleteDoctor(int doctorID);
        bool DoctorConfirmAdmin(int doctorID);
        bool ChangeSchedule(Schedule instance);
        IQueryable<Schedule> GetSchedulesToCurrentDoctor(int doctorID);
        IQueryable<Procedure> GetProcedures();
        IQueryable<Role> GetRoles();
        IQueryable<DoctorRole> GetDoctorRoles();
        bool AddRole (Role instance);
        bool MakeAdmin(int adminID, int roleID);
        Doctor GetDoctorByName(string name);
        Role GetRoleByName(string name);

        //--------------------

    }
}
