using System;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.CompanyViewModels;

namespace PostDriver.Api.Services
{
    public class CompanyService : ICompanyService
    {
        public Task AddCompanyAsync(CompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task EditCompanyAsync(CompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task GetCompaniesAsync(Guid RegionId)
        {
            throw new NotImplementedException();
        }
    }
}