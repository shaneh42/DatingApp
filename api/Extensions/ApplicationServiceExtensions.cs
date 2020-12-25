using System;
using api.Data;
using api.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();

            services.AddDbContext<DataContext>(options => options.UseMySql(
                config.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(10, 4, 17)),
                mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );

            return services;
        }
    }
}