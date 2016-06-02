using Autofac;
using Autofac.Extensions.DependencyInjection;
using CQRS.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using CQRS.Infrastructure.DependencyInjection;

namespace CQRS
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IActionContextAccessor, ActionContextAccessor>();

            var containerBuilder = new ContainerBuilder();

            Registration.Register(containerBuilder);
                       
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();

            var customDependencyConatinerBuilder = new ContainerBuilder();

            customDependencyConatinerBuilder.RegisterInstance<Infrastructure.DependencyInjection.Interfaces.DependencyInjection.ICustomDependencyResolver>(new CustomDependencyResolver(container));

            customDependencyConatinerBuilder.Update(container);

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
