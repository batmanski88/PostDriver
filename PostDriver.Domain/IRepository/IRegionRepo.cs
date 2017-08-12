using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Domain.Domain;

namespace PostDriver.Domain.IRepository
{
    public interface IRegionRepo : IRepository
    {
        Task<Region> GetRegionByIdAsync(Guid Id);
        Task<IEnumerable<Region>> GetRegionByOfficeIdAsync(Guid OfficeId);
        Task AddRegionAsync(Region Region);
        Task UpdateRegionAsync(Region Region);
        Task RemoveRegionAsync(Guid Id);
    }
}