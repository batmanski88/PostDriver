using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Domain.Domain;

namespace PostDriver.Domain.IRepository
{
    public interface ICompanyRepo : IRepository
    {
        Task<Company> GetCompanyByIdAsync(Guid Id);
        Task<Company> GetCompanyByNameAsync(string Name);
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task AddCompanyAsync(Company Company);
        Task UpdateCompanyAsync(Company Comapny);
        Task RemoveCompanyAsync(Guid Id);
    }
}