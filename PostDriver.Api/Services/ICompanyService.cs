using System;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.CompanyViewModels;

namespace PostDriver.Api.Services
{
    public interface ICompanyService : IService
    {
         Task GetCompaniesAsync(Guid RegionId);
         Task AddCompanyAsync(CompanyViewModel model);
         Task EditCompanyAsync(CompanyViewModel model);
         
    }
}