﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockTrackingApp.DataAccess.Contexts;

namespace StockTrackingApp.DataAccess.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StockAppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString(StockAppDbContext.ConnectionName),
                    options => options.EnableRetryOnFailure(
                        10,
                        TimeSpan.FromSeconds(10),
                        null));
                options.UseLazyLoadingProxies();
            });

            return services;
        }

    }
}
