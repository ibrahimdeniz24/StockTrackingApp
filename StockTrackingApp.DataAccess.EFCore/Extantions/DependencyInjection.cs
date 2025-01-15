using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockTrackingApp.DataAccess.EFCore.Repositories;


namespace StockTrackingApp.DataAccess.EFCore.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IApiUserRepository, ApiUserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSupplierRepository, ProductSupplierRepository>();
            services.AddScoped<IPurchaseOrderRepository,PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderDetailRepository, PurchaseOrderDetailRepository>();
            services.AddScoped<IStockTransactionRepository, StockTransactionRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();


            //AdminSeed.SeedAsync(configuration).GetAwaiter().GetResult();

            return services;
        }
    }
}
