using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config) => _config = config;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
            });
            
            services.AddControllers();

            services.AddDbContext<DataContext>(options => options.UseMySql(
                    _config.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(10, 4, 17)),
                    mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(_config["CorsOrigin"]));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
