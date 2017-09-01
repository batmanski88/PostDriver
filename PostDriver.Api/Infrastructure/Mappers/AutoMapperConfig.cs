using AutoMapper;
using PostDriver.Api.ViewModels.AccountViewModels;
using PostDriver.Api.ViewModels.PostOfficeViewModel;
using PostDriver.Domain.Domain;

namespace PostDriver.Api.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<User, RegisterViewModel>();
                cfg.CreateMap<User, LoginViewModel>();
                cfg.CreateMap<PostOffice, PostOfficeViewModel>();
                cfg.CreateMap<PostOffice, AddPostOfficeViewModel>();
            })
            .CreateMapper();
    }
}