using System.Reflection;
using Autofac;
using PostDriver.Api.Services;

namespace PostDriver.Api.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
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