using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetClinic.Models.ViewModels
{
    public class ScheduleView
    {
        public int ID { get; set; }
        public int Doctor { get; set; }
        public int Pet { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date { get; set; }

        [Required(ErrorMessage = "Введите заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите Текст")]
        public string Text { get; set; }
        public List<Doctor> DoctorList { get; set; }
        public List<Pet> PetList { get; set; }

        public string PetName { get; set; }
        public string Time { get; set; }

        public DateTime DateToDisplay { get; set;}
    }
}