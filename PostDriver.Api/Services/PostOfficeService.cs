using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PostDriver.Api.ViewModels.PostOfficeViewModel;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;

namespace PostDriver.Api.Services
{
    public class PostOfficeService : IPostOfficeService
    {
        private readonly IPostOfficeRepo _officeRepo;
        private readonly IMapper _mapper;

        public PostOfficeService(IPostOfficeRepo officeRepo, IMapper mapper)
        {
            _officeRepo = officeRepo;
            _mapper = mapper;
        }
        
        public async Task AddOfficeAsync(AddPostOfficeViewModel model)
        {
            var office = await _officeRepo.GetPostOfficeByName(model.Name);

            if(office != null)
            {
                throw new Exception("Urząd pocztowy już istnieje!");
            }

            office = new PostOffice(Guid.NewGuid(), model.Name, model.Adress, model.Longitude, model.Latitude);
            await _officeRepo.AddPostOfficeAsync(office);
        }

        public async Task<IEnumerable<PostOfficeViewModel>> GetOfficesAsync()
        {
            var offices = await _officeRepo.GetPostOfficesAsync();

            return _mapper.Map<IEnumerable<PostOfficeViewModel>>(offices);
        }

        public async Task RemoveOffice(Guid OfficeId)
        {
            await _officeRepo.RemovePostOfficeAsync(OfficeId);
        }
    }
}