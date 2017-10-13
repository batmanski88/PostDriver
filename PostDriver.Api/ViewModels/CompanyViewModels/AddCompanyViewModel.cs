using System;

namespace PostDriver.Api.ViewModels.CompanyViewModels
{
    public class AddCompanyViewModel
    {
       public Guid RegionId {get; set;}
       public string OfficeName {get; set;}
       public string Name {get; set; }
       public string Adress {get; set; }
       public double Longitude {get; set; }
       public double Latitude {get; set; }
       public DateTime StartHour {get; set; }
       public DateTime FinishHour {get; set; }
    }
}