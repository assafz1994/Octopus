using System.Collections.Generic;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OctopusCore;
using OctopusCore.Analyzer;
using OctopusCore.Configuration;
using OctopusCore.Configuration.Mocks;
using OctopusCore.DbHandlers;
using OctopusCore.Executor;
using OctopusCore.Parser;

namespace CommunicationLayer
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            // In ASP.NET Core 3.0 `env` will be an IWebHostEnvironment, not IHostingEnvironment.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Parser>().As<IParser>();
            builder.RegisterInstance(CreateDatabaseConfigurationManagerMock())
                .As<IDatabaseConfigurationManager>();
            builder.RegisterType<Analyzer>().As<IAnalyzer>();
            builder.RegisterType<Executor>().As<IExecutor>();
            builder.RegisterType<OctopusService>().As<IOctopusService>();

            IDatabaseConfigurationManager CreateDatabaseConfigurationManagerMock()
            {
                var entityTypeToFieldNameToDatabaseKeyMappings = new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "User", new Dictionary<string, string>
                        {
                            {"name", "Sql1"},
                            {"age", "Sql1"},
                            {"id", "Sql1"}
                        }
                    }
                };

                var databaseKeyToDbHandlerMappings = new Dictionary<string, IDbHandler>
                {
                    {"Sql1", new SqliteDbHandler()}
                };
                return new DatabaseConfigurationManagerMock(entityTypeToFieldNameToDatabaseKeyMappings,
                    databaseKeyToDbHandlerMappings);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}