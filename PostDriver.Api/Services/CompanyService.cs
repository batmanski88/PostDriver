using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.CompanyViewModels;
using PostDriver.Domain.Domain;
using PostDriver.Domain.Repository;
using Linq;
using AutoMapper;

namespace PostDriver.Api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyRepo _companyRepo;
        private readonly RegionRepo _regionRepo;
        private readonly IMapper _mapper;

        public CompanyService(CompanyRepo companyRepo, RegionRepo regionRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _regionRepo = regionRepo;
            _mapper = mapper;
        }
        public async Task AddCompanyAsync(CompanyViewModel model)
        {
            var company = await _companyRepo.GetCompanyByNameAsync(model.Name);
            if(company != null)
            {
                throw new Exception("Firma już istnieje w bazie!");
            }

            company = new Company(model.RegionId, Guid.NewGuid(), model.Name, model.Adress, model.Longitude, model.Latitude, model.StartHour, model.FinishHour);

            await _companyRepo.AddCompanyAsync(company);
        }

        public Task EditCompanyAsync(CompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompanyViewModel>> GetCompaniesAsync(Guid RegionId)
        {
            
        }

        public Task GetCompanyByIdAsync(Guid RegionId)
        {
            throw new NotImplementedException();
        }
    }
}