using System;

namespace PostDriver.Domain.Domain
{
    public class PostOffice
    {
        public Guid OfficeId {get; protected set; }
        public string Name {get; protected set; }
        public string Adress {get; protected set; }
        public double Longitude {get; protected set; }
        public double Latitude {get; protected set; }

        protected  PostOffice()
        {

        }

        public PostOffice(Guid officeId, string name, string adress, double longitude, double latitude)
        {
            OfficeId = officeId;
            SetName(name);
            SetAdress(adress);
            SetLongitude(longitude);
            SetLatitude(latitude);
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

        public void  SetLongitude(double longitude)
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

    }
}