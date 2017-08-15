using System;
using System.ComponentModel.DataAnnotations;

namespace PostDriver.Api.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {   
        [Key]
        public Guid UserId {get; set;}

        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Pole wymagane.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Wpisz poprawny adress email.")]
        public string Email {get; set; }

        [Display(Name = "Hasło: ")]
        [Required(ErrorMessage = "Pole wymagane.")]
        [DataType(DataType.Password)]
        public string Password {get; set; }

        [Display(Name = "Powtorz hasło: ")]
        [Required(ErrorMessage = "Pole wymagane.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same.")]
        public string ConfirmPassword {get; set; }

        [Display(Name = "Nazwa użytkownika: ")]
        [Required(ErrorMessage = "Pole wymagane.")]
        public string Username {get; set; }
     
    }
}