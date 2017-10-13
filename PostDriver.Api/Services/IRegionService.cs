using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.RegionViewModels;

namespace PostDriver.Api.Services
{
    public interface IRegionService
    {
         Task AddRegionAsync(RegionViewModel model);
         Task<IEnumerable<RegionViewModel>> GetRegionsByOfficeIdAsync(Guid OfficeId);
         Task RemoveRegionAsync(Guid RegionId);
    }
}