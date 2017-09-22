using System;
using System.ComponentModel.DataAnnotations;

namespace PostDriver.Api.ViewModels.PostOfficeViewModels
{
    public class AddPostOfficeViewModel
    {
        [Key]
        public Guid OfficeId {get; set; }

        [Display(Name = "Nazwa: ")]
        [Required(ErrorMessage = "Musisz podac nazwe.")]
        public string Name {get; set; }

        [Display(Name = "Adres: ")]
        [Required(ErrorMessage = "Musisz podac adres.")]
        public string Adress {get; set; }
        
        [Display(Name = "Długośc: ")]
        public decimal Longitude {get; set; }

        [Display(Name = "Szerokośc")]
        public decimal Latitude {get; set; }
    }
}