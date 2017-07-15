using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PostDriver.Api.Infrastructure.Settings;
using PostDriver.Api.Services;

namespace PostDriver.Api
{
    public class Startup
    {

        public IConfigurationRoot Configuration {get; }
        public IContainer ApplicationContainer {get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true )
                .AddJsonFile($"appsetings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<Encrypter>().As<IEncrypter>();
            builder.RegisterType<JwtHandler>().As<IJwtHandler>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.Populate(services);
            
            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            app.UseStaticFiles();

            app.UseMvc();

            var jwtSetting = app.ApplicationServices.GetService<JwtSettings>();
            app.UseJwtBearerAuthentication(new JwtBearerOptions {

                AutomaticAuthenticate = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "http://localhost/5000",
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key))
                }
            });
        }
    }
}
