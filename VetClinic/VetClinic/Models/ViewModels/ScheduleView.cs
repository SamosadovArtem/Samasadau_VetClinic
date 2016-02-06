using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetClinic.Models.ViewModels
{
    public class ScheduleView
    {
        public int Doctor { get; set; }
        public int Pet { get; set; }
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Введите заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите Текст")]
        public string Text { get; set; }
        public List<Doctor> DoctorList { get; set; }
        public List<Pet> PetList { get; set; }
    }
}