using Microsoft.Extensions.DependencyInjection;
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Business.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAdminService,AdminService>();

            return services;
        }
    }
}
