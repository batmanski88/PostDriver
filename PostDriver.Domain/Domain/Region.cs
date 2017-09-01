using System;
using System.Collections.Generic;

namespace PostDriver.Domain.Domain
{
    public class Region
    {
        public Guid RegionId {get; protected set;}
        public Guid PostOfficeId {get; protected set;}
        public string RegionName {get; protected set;}

        public Region(Guid regionId, string regionName, Guid postOfficeId)
        {
            RegionId = regionId;
            SetRegionName(regionName);
            SetPostOfficeId(postOfficeId);
        }

        public void SetPostOfficeId(Guid postOfficeId)
        {
            PostOfficeId = postOfficeId;
        }

        public void SetRegionName(string regionName)
        {
            RegionName = regionName;
        }
    }
}