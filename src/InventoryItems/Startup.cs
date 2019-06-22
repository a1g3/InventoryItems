using Autofac;
using AutoMapper;
using InventoryItems.Controllers;
using InventoryItems.Data;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain;
using InventoryItems.Domain.Infastructure;
using InventoryItems.Domain.Interfaces.Infastructure;
using InventoryItems.Domain.Models;
using InventoryItems.Helpers;
using InventoryItems.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace InventoryItems
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services) {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddMvc(option => option.EnableEndpointRouting = false).AddControllersAsServices();
            services.AddDbContext<InventoryContext>(ServiceLifetime.Scoped);

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<UserContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<User, UserContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });
        }

        public void ConfigureContainer(ContainerBuilder builder) {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly(), Assembly.Load("InventoryItems.Domain"), Assembly.Load("InventoryItems.Data"))
                .AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterType<CollectionsController>().PropertiesAutowired();
            builder.RegisterType<AccountsController>().PropertiesAutowired();
            builder.RegisterType<CoinsController>().PropertiesAutowired();

            var settings = new Settings();
            Configuration.Bind(settings);
            builder.RegisterInstance(settings).As<ISettings>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            Mapper.Initialize(config => {
                config.AddProfile<WebMapperProfile>();
                config.AddProfile<DomainMapperProfile>();
                config.AddProfile<DataMapperProfile>();
            });
            //Mapper.AssertConfigurationIsValid();

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "project",
                    template: "collection/{collectionId}"
                    );

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
