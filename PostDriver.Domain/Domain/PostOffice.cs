using System;

namespace PostDriver.Domain.Domain
{
    public class PostOffice
    {
        public Guid OfficeId {get; protected set; }
        public string Name {get; protected set; }
        public string Adress {get; protected set; }
        public double Longtitude {get; protected set; }
        public double Latitude {get; protected set; }

        public PostOffice()
        {

        }

        public PostOffice(string name, string adress, double longtitude, double latitude)
        {
            
        }

        public void SetOfficeId(Guid officeId)
        {
            OfficeId = officeId;
        }

        public void SetName(string name)
        {
            if(Name == name)
            {
                return;
            }
            Name = name;
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

    }
}