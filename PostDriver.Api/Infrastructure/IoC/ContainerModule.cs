using Autofac;
using Microsoft.Extensions.Configuration;
using PostDriver.Api.Infrastructure.IoC.Modules;
using PostDriver.Api.Infrastructure.Mappers;

namespace PostDriver.Api.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        
        private readonly IConfiguration _configuration;
        public IContainer ApplicationContainer { get; private set; }
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.RegisterModule(new SettingModule(_configuration));
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();
        }
    }
}   