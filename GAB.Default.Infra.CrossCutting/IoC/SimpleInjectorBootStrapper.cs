using SimpleInjector;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Extensions.Caching.Memory;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using $ext_projectname$.Infra.Data.Context;
using $ext_projectname$.Domain.Core.Interfaces.Repositories;
using $ext_projectname$.Infra.Data.UoW;
using $ext_projectname$.Application.Interfaces;
using $ext_projectname$.Application.Services;
using $ext_projectname$.Domain.Core.Interfaces.Services;
using $ext_projectname$.Domain.Services.Services;
using $ext_projectname$.Infra.Data.Repositories;
using $ext_projectname$.Application.AutoMapper;
using AutoMapper;
using SimpleInjector.Lifestyles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using SimpleInjector.Integration.AspNetCore.Mvc;

namespace $safeprojectname$.IoC
{
    public class SimpleInjectorBootStrapper
    {
        public Container container = new Container();
        private string _connectionString { get; set; }

        public void InitializeContainer(IApplicationBuilder app, IConfiguration configuration)
        {
            container.Register(() => configuration, Lifestyle.Scoped);

            app.UseSimpleInjector(container);

            _connectionString = configuration.GetConnectionString("DefaultConnection");

            container.Register<IDbConnection>(() => new SqlConnection(_connectionString), Lifestyle.Scoped);
            container.Register<DbContextOptions>(() =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer(_connectionString);
                return optionsBuilder.Options;
            }, Lifestyle.Scoped);
            container.Register<DbContext, DatabaseContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<IMemoryCache>(() => new MemoryCache(new MemoryCacheOptions() { SizeLimit = 5000 }), Lifestyle.Singleton);

            container.Register<IPersonSampleAppService, PersonSampleAppService>(Lifestyle.Scoped);
            container.Register<IPersonSampleService, PersonSampleService>(Lifestyle.Scoped);
            container.Register<IPersonSampleRepository, PersonSampleRepository>(Lifestyle.Scoped);

            var config = AutoMapperConfig.RegisterMappings();
            container.RegisterInstance<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
        }

        public void SetDefaultScopedLifestyle(ScopedLifestyle scope = null)
        {
            container.Options.DefaultScopedLifestyle = scope ?? new AsyncScopedLifestyle();
        }

        public void IntegrateSimpleInjector(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and
                // allows request-scoped framework services to be resolved.
                options.AddAspNetCore()

                    // Ensure activation of a specific framework type to be created by
                    // Simple Injector instead of the built-in configuration system.
                    // All calls are optional. You can enable what you need. For instance,
                    // ViewComponents, PageModels, and TagHelpers are not needed when you
                    // build a Web API.
                    .AddControllerActivation();

                // Optionally, allow application components to depend on the non-generic
                // ILogger (Microsoft.Extensions.Logging) or IStringLocalizer
                // (Microsoft.Extensions.Localization) abstractions.
                options.AddLogging();
            });

            services.AddScoped<DatabaseContext>();
        }

        public void SetContainer(Container container)
        {
            this.container = container;
        }

        public void Verify()
        {
            container.Verify();
        }
    }
}
