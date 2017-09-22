using System;

namespace PostDriver.Domain.Domain
{
    public class PostOffice
    {
        public Guid OfficeId {get; protected set; }
        public string Name {get; protected set; }
        public string Adress {get; protected set; }
        public decimal Longitude {get; protected set; }
        public decimal Latitude {get; protected set; }

        protected  PostOffice()
        {

        }

        public PostOffice(Guid officeId, string name, string adress, decimal longitude, decimal latitude)
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

        public void  SetLongitude(decimal longitude)
        {
           if(Longitude == longitude)
           {
               return;
           }
           Longitude = longitude;
        }

        public void SetLatitude(decimal latitude)
        {
           if(Latitude == latitude)
           {
               return;
           }
           Latitude = latitude;
        }

    }
}