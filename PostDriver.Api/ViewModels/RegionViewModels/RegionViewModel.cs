using System;
using System.ComponentModel.DataAnnotations;

namespace PostDriver.Api.ViewModels.RegionViewModels
{
    public class RegionViewModel
    {
        [Required(ErrorMessage = "Pole wymagane.")]
        [Display(Name = "Nazwa Urzędu: ")]
        public string OfficeName {get; set;}
        [Required]
        [Display(Name = "Nazwa Rejonu: ")]
        public string Name {get; set; }
    }
}