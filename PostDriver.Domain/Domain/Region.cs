using System;
using System.Collections.Generic;

namespace PostDriver.Domain.Domain
{
    public class Region
    {
        public Guid RegionId {get; protected set;}
        public Guid PostOfficeId {get; protected set;}
        public string RegionName {get; protected set;}

        public Region(string regionName, Guid postOfficeId)
        {
            RegionName = regionName;
            PostOfficeId = postOfficeId;
        }
    }
}