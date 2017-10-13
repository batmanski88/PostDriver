using System;

namespace PostDriver.Domain.Domain
{
    public class Company
    {
       public Guid CompanyId {get; protected set; }
       public Guid RegionId {get; protected set; }
       public string Name {get; protected set; }
       public string Adress {get; protected set; }
       public double Longitude {get; protected set; }
       public double Latitude {get; protected set; }
       public DateTime StartHour {get; protected set; }
       public DateTime FinishHour {get; protected set; }

       protected Company()
       {

       }

       public Company(Guid regionId, Guid companyId, string name,string adress, double longitude, double latitude, DateTime starHour, DateTime finishHour)
       {
            CompanyId = companyId;
            SetRegionId(regionId);
            SetName(name);
            SetAdress(adress);
            SetLongtitude(longitude);
            SetLatitude(latitude);
            SetStartHour(starHour);
            SetFinishHour(finishHour);
       }

      
       public void SetName(string name)
       {
           if(Name == name)
           {
               return;
           }
           Name = name; 
       }

       public void SetRegionId(Guid regionId)
       {
           RegionId = regionId;
       }
       
       public void SetAdress(string adress)
       {
           if(Adress == adress)
           {
               return;
           }
           Adress = adress;
       }

       public void  SetLongtitude(double longitude)
       {
           if(Longitude == longitude)
           {
               return;
           }
           Longitude = longitude;
       }

       public void SetLatitude(double latitude)
       {
           if(Latitude == latitude)
           {
               return;
           }
           Latitude = latitude;
       }

       public void SetStartHour(DateTime startHour)
       {
           if(StartHour == startHour)
           {
                return;
           }
           StartHour = startHour;
       }

       public void SetFinishHour(DateTime finishHour)
       {
           if(FinishHour == finishHour)
           {
               return;
           }
           FinishHour = finishHour;
       }
       
       
    }
}