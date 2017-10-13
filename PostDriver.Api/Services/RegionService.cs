using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PostDriver.Api.ViewModels.RegionViewModels;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;
using PostDriver.Domain.Repository;

namespace PostDriver.Api.Services
{
    public class RegionService : IRegionService
    {
        private  readonly IPostOfficeService _officeService;
        private readonly IRegionRepo _regionRepo;
        private readonly IMapper _mapper;

        public RegionService(IPostOfficeService officeService, IRegionRepo regionRepo, IMapper mapper)
        {
            _officeService = officeService;
            _regionRepo = regionRepo;
            _mapper = mapper;
        }

        public async Task AddRegionAsync(RegionViewModel model)
        {
            var office = await _officeService.GetPostOfficeByNameAsync(model.OfficeName);

            if(office == null)
            {
                throw new Exception("Taki urząd pocztowy nie istnieje!");
            }

            var region = new Region(Guid.NewGuid(), office.OfficeId, model.Name);

            await _regionRepo.AddRegionAsync(region);
        }

        public async Task<IEnumerable<RegionViewModel>> GetRegionsByOfficeIdAsync(Guid OfficeId)
        {
            var regions = await _regionRepo.GetRegionByOfficeIdAsync(OfficeId);

            return _mapper.Map<IEnumerable<RegionViewModel>>(regions);
        }

        public async Task RemoveRegionAsync(Guid RegionId)
        {
            await _regionRepo.RemoveRegionAsync(RegionId);
        }
    }
}