using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PCConfiguration.Core.Interfaces;
using PCConfiguration.Core.Services;
using PCConfiguration.Data;
using PCConfiguration.Data.Implementations.Repositories;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;

namespace PCConfigurationClient
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
            services.AddControllersWithViews();
            services.AddSingleton(typeof(PcDbContext));
            RegisterRepositories(services);
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IGenericService<IGenericRepository<Case>, Case>), typeof(GenericService<IGenericRepository<Case>, Case>));
            services.AddSingleton(typeof(IGenericService<IGenericRepository<CPU>, CPU>), typeof(GenericService<IGenericRepository<CPU>, CPU>));
            services.AddSingleton(typeof(IGenericService<IGenericRepository<CPUCooler>, CPUCooler>), typeof(GenericService<IGenericRepository<CPUCooler>, CPUCooler>));
            services.AddSingleton(typeof(IGenericService<IGenericRepository<Memory>, Memory>), typeof(GenericService<IGenericRepository<Memory>, Memory>));
            services.AddSingleton(typeof(IGenericService<IGenericRepository<Motherboard>, Motherboard>), typeof(GenericService<IGenericRepository<Motherboard>, Motherboard>));
            services.AddSingleton(typeof(IGenericService<IGenericRepository<PowerSupply>, PowerSupply>), typeof(GenericService<IGenericRepository<PowerSupply>, PowerSupply>));
            services.AddSingleton(typeof(IGenericService<IGenericRepository<Storage>, Storage>), typeof(GenericService<IGenericRepository<Storage>, Storage>));
            services.AddSingleton(typeof(IGenericService<IGenericRepository<VideoCard>, VideoCard>), typeof(GenericService<IGenericRepository<VideoCard>, VideoCard>));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton(typeof(IGenericRepository<Case>), typeof(GenericRepository<Case>));
            services.AddSingleton(typeof(IGenericRepository<PowerSupply>), typeof(GenericRepository<PowerSupply>));
            services.AddSingleton(typeof(IGenericRepository<CPU>), typeof(GenericRepository<CPU>));
            services.AddSingleton(typeof(IGenericRepository<CPUCooler>), typeof(GenericRepository<CPUCooler>));
            services.AddSingleton(typeof(IGenericRepository<Memory>), typeof(GenericRepository<Memory>));
            services.AddSingleton(typeof(IGenericRepository<Storage>), typeof(GenericRepository<Storage>));
            services.AddSingleton(typeof(IGenericRepository<VideoCard>), typeof(GenericRepository<VideoCard>));
            services.AddSingleton(typeof(IGenericRepository<Motherboard>), typeof(GenericRepository<Motherboard>));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
