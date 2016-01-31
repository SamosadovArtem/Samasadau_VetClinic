using System.ComponentModel.DataAnnotations;
using VetClinic.Infrastructure.Validation;

namespace VetClinic.Models.ViewModels
{
    public class ClientView
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите Email")]
        [EmailValidation(ErrorMessage = "Введите корректный Email")]
        public string Email { get; set; }
    }
}