using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockTrackingApp.DataAccess.EFCore.Repositories;
using StockTrackingApp.DataAccess.EFCore.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.DataAccess.EFCore.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockTransactionRepository, StockTransactionRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            AdminSeed.SeedAsync(configuration).GetAwaiter().GetResult();

            return services;
        }
    }
}
