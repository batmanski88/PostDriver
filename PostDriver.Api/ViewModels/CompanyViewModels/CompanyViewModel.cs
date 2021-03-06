using System;

namespace PostDriver.Api.ViewModels.CompanyViewModels
{
    public class CompanyViewModel
    {
       public Guid CompanyId {get; set;}
       public Guid RegionId {get; set; }
       public string Name {get; set; }
       public string Adress {get; set; }
       public double Longitude {get; set; }
       public double Latitude {get; set; }
       public DateTime StartHour {get; set; }
       public DateTime FinishHour {get; set; }
    }
}