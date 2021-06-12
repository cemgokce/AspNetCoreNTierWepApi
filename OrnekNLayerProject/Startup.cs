using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using OrnekNLayerProject.Core.Repositories;
using OrnekNLayerProject.Core.Services;
using OrnekNLayerProject.Core.UnitOfWork;
using OrnekNLayerProject.Data;
using OrnekNLayerProject.Data.Repositories;
using OrnekNLayerProject.Data.UnitOfWork;
using OrnekNLayerProject.Service.Service;
using AutoMapper;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrnekNLayerProject.Filters;
using Microsoft.AspNetCore.Diagnostics;
using OrnekNLayerProject.DTOs;
using Microsoft.AspNetCore.Http;
using OrnekNLayerProject.Extencions;

namespace OrnekNLayerProject
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
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped(typeof(IRepositories<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Service.Service<>));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(),o=> {
                    o.MigrationsAssembly("OrnekNLayerProject.Data");
                });
            });

           

            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddScoped<NotFoundFilter>();
        }
     

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
