using Autofac;
using AutoMapper;
using InventoryItems.Controllers;
using InventoryItems.Data;
using InventoryItems.Domain;
using InventoryItems.Domain.Interfaces.Infastructure;
using InventoryItems.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Reflection;
using System.Text;

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

            services.AddMvc().AddControllersAsServices();
            services.AddDbContext<InventoryContext>(ServiceLifetime.Scoped);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Domain"],
                    ValidAudience = Configuration["Domain"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                                    Encoding.UTF8.GetBytes(Configuration["TokenSecurityKey"]))
                };
            });
        }

        public void ConfigureContainer(ContainerBuilder builder) {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly(), Assembly.Load("InventoryItems.Domain"), Assembly.Load("InventoryItems.Data"))
                .AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterType<CollectionsController>().PropertiesAutowired();
            builder.RegisterType<AccountsController>().PropertiesAutowired();
            builder.RegisterType<CoinsController>().PropertiesAutowired();
            builder.RegisterType<MapperProvider>().As<IMapper>();

            var settings = new Settings();
            Configuration.Bind(settings);
            builder.RegisterInstance(settings).As<ISettings>();
            builder.RegisterModule<MapperProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
