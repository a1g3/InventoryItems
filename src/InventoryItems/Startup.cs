using Autofac;
using CoinCompanion.Web.Server.Controllers;
using CoinCompanion.Web.Server.Helpers;
using InventoryItems.Data;
using InventoryItems.Domain;
using InventoryItems.Domain.Interfaces.Infastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace CoinCompanion.Web.Server
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services) {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddControllersWithViews();
            services.AddDbContext<InventoryContext>(ServiceLifetime.Scoped);
        }

        public void ConfigureContainer(ContainerBuilder builder) {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly(), Assembly.Load("InventoryItems.Domain"), Assembly.Load("InventoryItems.Data"))
                .AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterType<CollectionsController>().PropertiesAutowired();
            builder.RegisterType<AccountsController>().PropertiesAutowired();
            builder.RegisterType<CoinsController>().PropertiesAutowired();
            builder.RegisterModule<MapperProvider>();

            var settings = new Settings();
            Configuration.Bind(settings);
            builder.RegisterInstance(settings).As<ISettings>();
            builder.RegisterModule<MapperProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
