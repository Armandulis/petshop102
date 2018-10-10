using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PetShop.Core.AplicationService;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainSerivice;
using PetShop.Core.Entity;
using PetShop.Infrastucture.Data;
using PetShop.Infrastucture.Data.Repositories;
using System.Collections.Generic;

namespace PetRestAPI
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
            /*services.AddDbContext<PetShopContext>(
                option => option.UseInMemoryDatabase("Databasu")
                );*/

            services.AddDbContext<PetShopContext>(
                option => option.UseSqlite("Data Source=petShopApp.db"));

            
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope()) {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    InitialiseDB.SeedDB(ctx);
                } 
            }
            else {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
