using System;

namespace PostDriver.Api.ViewModels.CompanyViewModels
{
    public class CompanyViewModel
    {
       public Guid RegionId {get; protected set; }
       public string Name {get; protected set; }
       public string Adress {get; protected set; }
       public double Longitude {get; protected set; }
       public double Latitude {get; protected set; }
       public DateTime StartHour {get; protected set; }
       public DateTime FinishHour {get; protected set; }
    }
}