using System.Reflection;
using Autofac;
using PostDriver.Api.Services;

namespace PostDriver.Api.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostOfficeService>()
                   .As<IPostOfficeService>()
                   .InstancePerLifetimeScope();
            
            builder.RegisterType<RegionService>()
                   .As<IRegionService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<CompanyService>()
                   .As<ICompanyService>()
                   .InstancePerLifetimeScope();
                   
            builder.RegisterType<UserService>()
                   .As<IUserService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                   .As<IEncrypter>()
                   .SingleInstance();

            builder.RegisterType<JwtHandler>()
                   .As<IJwtHandler>()
                   .SingleInstance();
            
        }
    }
}