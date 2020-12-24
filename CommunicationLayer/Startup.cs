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
using OctopusCore.Configuration.ConfigurationProviders;
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
            var reader = new ConfigurationAndSchemeReader(Configuration["DbConfigurationFilePath"],
                Configuration["SchemeFilePath"]);

            builder.RegisterInstance(reader.DbConfigurations).As<DbConfigurations>();
            builder.RegisterInstance(reader.Scheme).As<Scheme>();
            builder.RegisterType<DbHandlersResolver>().As<IDbHandlersResolver>();
            builder.RegisterType<AnalyzerConfigurationProvider>().As<IAnalyzerConfigurationProvider>();
            builder.RegisterType<Parser>().As<IParser>();
            builder.RegisterType<Analyzer>().As<IAnalyzer>();
            builder.RegisterType<Executor>().As<IExecutor>();
            builder.RegisterType<OctopusService>().As<IOctopusService>();

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