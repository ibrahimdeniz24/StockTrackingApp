using Microsoft.Extensions.DependencyInjection;
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Business.Services;
using System.Reflection;


namespace StockTrackingApp.Business.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAdminService,AdminService>();
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IEmailService,EmailService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IOrderDetailService,OrderDetailService>();
            services.AddScoped<IOrderService,OrderService>();

            return services;
        }
    }
}
