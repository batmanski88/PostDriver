using Autofac;
using Microsoft.Extensions.Configuration;
using PostDriver.Api.Infrastructure.Extensions;
using PostDriver.Api.Infrastructure.Settings;

namespace PostDriver.Api.Infrastructure.IoC.Modules
{
    public class SettingModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        
        public SettingModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
		
        }
    }
}