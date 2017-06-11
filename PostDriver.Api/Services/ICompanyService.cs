using System;
using System.Threading.Tasks;

namespace PostDriver.Api.Services
{
    public interface ICompanyService
    {
         Task GetCompaniesAsync(Guid RegionId);
         
    }
}