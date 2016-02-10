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



        //--------------------

        Doctor Login(string email, string password);
        Doctor GetUser(string email);

        //--------------------

    }
}
