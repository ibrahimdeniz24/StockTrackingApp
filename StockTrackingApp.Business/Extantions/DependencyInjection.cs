using Microsoft.Extensions.DependencyInjection;
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Business.Profiles;
using StockTrackingApp.Business.Services;
using System.Reflection;


namespace StockTrackingApp.Business.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CategoryProfile).Assembly);


            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAdminService,AdminService>();
            services.AddScoped<IApiUserService, ApiUserService>();
            services.AddScoped<IBreadcrumbService,BreadcrumbService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<IEmailService,EmailService>();
            services.AddScoped<IOrderDetailService,OrderDetailService>();
            services.AddScoped<IOrderService,OrderService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IProductSupplierService,ProductSupplierService>();
            services.AddScoped<IPurchaseOrderService,PurchaseOrderService>();
            services.AddScoped<IPurchaseOrderDetailService,PurchaseOrderDetailService>();
            services.AddScoped<IStockService,StockService>();
            services.AddScoped<IStockTransactionService,StockTransactionService>();
            services.AddScoped<ISupplierService,SupplierService>();
            services.AddScoped<IWarehouseService,WarehouseService>();
            services.AddScoped<IDashboardService,DashBoardService>();
            services.AddScoped<ISendMailService,SendMailService>();

            return services;
        }
    }
}
