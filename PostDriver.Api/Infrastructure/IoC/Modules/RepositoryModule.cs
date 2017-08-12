using System.Reflection;
using Autofac;
using PostDriver.Domain.IRepository;
using PostDriver.Domain.Repository;

namespace PostDriver.Api.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
         protected override void Load(ContainerBuilder builder)
        {
                
            builder.RegisterType<ConnectionFactory>()
                   .As<IConnectionFactory>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UserRepo>()
                   .As<IUserRepo>()
                   .InstancePerLifetimeScope();
        }
    }
}