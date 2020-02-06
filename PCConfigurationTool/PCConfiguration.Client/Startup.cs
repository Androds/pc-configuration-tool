using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Core.Services;
using PCConfiguration.Data;
using PCConfiguration.Data.Implementations.Repositories;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;

namespace PCConfiguration.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(PcDbContext));
            services.AddControllersWithViews();
            services.AddSession(options =>
            {
                //options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                //options.Cookie.IsEssential = true;
            });
            services.AddMvc().AddSessionStateTempDataProvider();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            RegisterRepositories(services);
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IService<IRepository<Case>, Case>), typeof(CaseService));
            services.AddSingleton(typeof(IService<IRepository<CPU>, CPU>), typeof(CPUService));
            services.AddSingleton(typeof(IService<IRepository<CPUCooler>, CPUCooler>), typeof(CPUCoolerService));
            services.AddSingleton(typeof(IService<IRepository<Memory>, Memory>), typeof(MemoryService));
            services.AddSingleton(typeof(IService<IRepository<Motherboard>, Motherboard>), typeof(MotherboardService));
            services.AddSingleton(typeof(IService<IRepository<PowerSupply>, PowerSupply>), typeof(PowerSupplyService));
            services.AddSingleton(typeof(IService<IRepository<Storage>, Storage>), typeof(StorageService));
            services.AddSingleton(typeof(IService<IRepository<VideoCard>, VideoCard>), typeof(VideoCardService));
        }
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository<Case>), typeof(CaseRepository));
            services.AddSingleton(typeof(IRepository<PowerSupply>), typeof(PowerSupplyRepository));
            services.AddSingleton(typeof(IRepository<CPU>), typeof(CPURepository));
            services.AddSingleton(typeof(IRepository<CPUCooler>), typeof(CPUCoolerRepository));
            services.AddSingleton(typeof(IRepository<Memory>), typeof(MemoryRepository));
            services.AddSingleton(typeof(IRepository<Storage>), typeof(StorageRepository));
            services.AddSingleton(typeof(IRepository<VideoCard>), typeof(VideoCardRepository));
            services.AddSingleton(typeof(IRepository<Motherboard>), typeof(MotherboardRepository));
        }
    }
}
