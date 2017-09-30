using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.CompanyViewModels;
using PostDriver.Domain.Domain;
using PostDriver.Domain.Repository;
using AutoMapper;
using PostDriver.Domain.IRepository;

namespace PostDriver.Api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepo _companyRepo;
        private readonly IRegionRepo _regionRepo;
        private readonly IPostOfficeRepo _officeRepo;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepo companyRepo, IRegionRepo regionRepo, IPostOfficeRepo officeRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _regionRepo = regionRepo;
            _mapper = mapper;
        }
        public async Task AddCompanyAsync(AddCompanyViewModel model)
        {
            var company = await _companyRepo.GetCompanyByNameAsync(model.Name);
            if(company != null)
            {
                throw new Exception("Firma już istnieje w bazie!");
            }
            
            var office = await _officeRepo.GetPostOfficeByName(model.Name);
            var region = await _regionRepo.GetRegionByOfficeIdAsync(office.OfficeId);
            
            company = new Company(region.RegionId, Guid.NewGuid(), model.Name, model.Adress, model.Longitude, model.Latitude, model.StartHour, model.FinishHour);

            await _companyRepo.AddCompanyAsync(company);
        }

        public Task EditCompanyAsync(CompanyViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompanyViewModel>> GetCompaniesAsync(Guid RegionId)
        {
            throw new NotImplementedException();
        }

        public Task GetCompanyByIdAsync(Guid RegionId)
        {
            throw new NotImplementedException();
        }
    }
}