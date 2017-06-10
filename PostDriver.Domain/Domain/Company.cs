using System;

namespace PostDriver.Domain.Domain
{
    public class Company
    {
       public Guid CompanyId {get; protected set; }
       public Guid RegionId {get; protected set; }
       public string Name {get; protected set; }
       public string Adress {get; protected set; }
       public double Longtitude {get; protected set; }
       public double Latitude {get; protected set; }
       public DateTime StartHour {get; protected set; }
       public DateTime FinishHour {get; protected set; }

       public Company()
       {

       }

       public Company(Guid RegionId, string name,string adress, double longtitude, double latitude, DateTime starHour, DateTime finishHour)
       {
            CompanyId = Guid.NewGuid();
            Name = name;
            StartHour = starHour;
            FinishHour = finishHour;
            Adress = adress;
            Longtitude = longtitude;
            Latitude = latitude;
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

       public void  SetLongtitude(double longtitude)
       {
           if(Longtitude == longtitude)
           {
               return;
           }
           Longtitude = longtitude;
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