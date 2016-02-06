using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetClinic.Models.ViewModels
{
    public class PetView
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string name { get; set; }

        [Required(ErrorMessage = "Введите имя хозяина")]
        public int master { get; set; }

        [Required(ErrorMessage = "Введите породу")]
        public string kind { get; set; }
        public List<Client> mastersList { get; set; }

    }
}