using System;
using System.ComponentModel.DataAnnotations;

namespace PostDriver.Api.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {   
        public Guid TokenId {get ; set; }
        
        [Display(Name = "Email: ")]
        [EmailAddress(ErrorMessage = "Musisz wpisac poprawny adress email.")]
        public string Email {get; set; }

        [Display(Name = "Haslo: ")]
        [DataType(DataType.Password, ErrorMessage = "Wpisz poprawne haslo.")]
        public string Password {get; set;}
    }
}