using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.CompanyViewModels;

namespace PostDriver.Api.Services
{
    public interface ICompanyService : IService
    {
         Task GetCompanyByIdAsync(Guid RegionId);
         Task AddCompanyAsync(CompanyViewModel model);
         Task EditCompanyAsync(CompanyViewModel model);
         Task<IEnumerable<CompanyViewModel>> GetCompaniesAsync(Guid RegionId);
         
    }
}