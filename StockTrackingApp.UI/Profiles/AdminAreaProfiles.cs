using AutoMapper;
using StockTrackingApp.Dtos.Admins;
using StockTrackingApp.Dtos.ApiUsers;
using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Dtos.Customers;
using StockTrackingApp.Dtos.Products;
using StockTrackingApp.Dtos.Suppliers;
using StockTrackingApp.UI.Areas.Admin.Models.AdminVMs;
using StockTrackingApp.UI.Areas.Admin.Models.ApiUserVMs;
using StockTrackingApp.UI.Areas.Admin.Models.CategoryVMs;
using StockTrackingApp.UI.Areas.Admin.Models.CustomerVMs;
using StockTrackingApp.UI.Areas.Admin.Models.ProductVMs;
using StockTrackingApp.UI.Areas.Admin.Models.SupplierVMs;

namespace StockTrackingApp.UI.Profiles
{
    public class AdminAreaProfiles : Profile
    {
        public AdminAreaProfiles()
        {

            //AdminController
            CreateMap<AdminAdminCreateVM, AdminCreateDto>();
            CreateMap<AdminDetailsDto, AdminAdminDetailsVM>();
            CreateMap<AdminListDto, AdminAdminListVM>();
            CreateMap<AdminAdminUpdateVM, AdminUpdateDto>();
            CreateMap<AdminDto, AdminAdminVM>();



            //ApiUserController
            CreateMap<AdminApiUserCreateVM, ApiUserCreateDto>();
            CreateMap<ApiUserDetailsDto, AdminApiUserDetailsVM>();
            CreateMap<ApiUserListDto, AdminApiUserListVM>();
            CreateMap<AdminApiUserUpdateVM, ApiUserUpdateDto>();
            CreateMap<ApiUserDto, AdminApiUserVM>();


            //CategoryController
            CreateMap<AdminCategoryCreateVM, CategoryCreateDto>();
            CreateMap<CategoryDetailsDto, AdminCategoryDetailsVM>();
            CreateMap<CategoryListDto, AdminCategoryListVM>();
            CreateMap<AdminCategoryUpdateVM, CategoryUpdateDto>();
            CreateMap<CategoryDto, AdminCategoryVM>();

            //CustomerController
            CreateMap<AdminCustomerCreateVM, CustomerCreateDto>();
            CreateMap<CustomerDetailsDto, AdminCustomerDetailsVM>();
            CreateMap<CustomerListDto, AdminCustomerListVM>();
            CreateMap<AdminCustomerUpdateVM, CustomerUpdateDto>();
            CreateMap<CustomerDto, AdminCustomerVM>();


            //SupplierController
            CreateMap<AdminSupplierCreateVM, SupplierCreateDto>();
            CreateMap<SupplierDetailsDto, AdminSupplierDetailsVM>();
            CreateMap<SupplierListDto, AdminSupplierListVM>();
            CreateMap<AdminSupplierUpdateVM, SupplierUpdateDto>();
            CreateMap<SupplierDto, AdminSupplierVM>();



            //ProductController
            CreateMap<AdminProductCreateVM, ProductCreateDto>();
            CreateMap<ProductListDto, AdminProductListVM>();
    
        }
    }
}
