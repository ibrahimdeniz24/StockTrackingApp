﻿using AutoMapper;
using StockTrackingApp.Dtos.Admins;
using StockTrackingApp.Dtos.ApiUsers;
using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Dtos.Customers;
using StockTrackingApp.Dtos.OrderDetails;
using StockTrackingApp.Dtos.Orders;
using StockTrackingApp.Dtos.Products;
using StockTrackingApp.Dtos.PurchaseOrders;
using StockTrackingApp.Dtos.Stocks;
using StockTrackingApp.Dtos.Suppliers;
using StockTrackingApp.Dtos.Warehouses;
using StockTrackingApp.UI.Areas.Admin.Models.AdminVMs;
using StockTrackingApp.UI.Areas.Admin.Models.ApiUserVMs;
using StockTrackingApp.UI.Areas.Admin.Models.CategoryVMs;
using StockTrackingApp.UI.Areas.Admin.Models.CustomerVMs;
using StockTrackingApp.UI.Areas.Admin.Models.OrderDetailVMs;
using StockTrackingApp.UI.Areas.Admin.Models.OrderVMs;
using StockTrackingApp.UI.Areas.Admin.Models.ProductVMs;
using StockTrackingApp.UI.Areas.Admin.Models.PurchaseOrderVMs;
using StockTrackingApp.UI.Areas.Admin.Models.StockVMs;
using StockTrackingApp.UI.Areas.Admin.Models.SupplierVMs;
using StockTrackingApp.UI.Areas.Admin.Models.WarehouseVMs;

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
            CreateMap<AdminProductUpdateVM, ProductUpdateDto>();
            CreateMap<ProductListDto, AdminProductListVM>();
            CreateMap<ProductDetailsDto, AdminProductDetailsVM>();
            CreateMap<ProductListDto, AdminProductListVM>();
            CreateMap<ProductDto, AdminProductListVM>();



            //WarehouseController
            CreateMap<AdminWarehouseCreateVM, WarehouseCreateDto>();
            CreateMap<WarehouseDetailsDto, AdminWarehouseDetailsVM>();
            CreateMap<WarehouseListDto, AdminWarehouseListVM>();
            CreateMap<AdminWarehouseUpdateVM, WarehouseUpdateDto>();


            //StockController
            CreateMap<StockDto, AdminStockVM>();
            CreateMap<StockListDto, AdminStockListVM>();
            CreateMap<StockDetailsDto, AdminStockDetailsVM>();
            CreateMap<AdminStockCreateVM, StockCreateDto>();
            CreateMap<AdminStockUpdateVM, StockUpdateDto>();


            //OrderController
            CreateMap<OrderDto, AdminOrderVM>();
            CreateMap<OrderListDto, AdminOrderListVM>();
            CreateMap<OrderDetailsDto, AdminOrderDetailsVM>();
            CreateMap<AdminOrderCreateVM, OrderCreateDto>()
                 .ForMember(dest => dest.OrderDetailDtos, opt => opt.MapFrom(src => src.AdminOrderDetailCreateVMs));
            CreateMap<AdminOrderUpdateVM, OrderUpdateDto>()
                .ForMember(dest => dest.OrderDetailDtos, opt => opt.MapFrom(src => src.AdminOrderDetailUpdateVMs));


            //OrderDetailController
            CreateMap<AdminOrderDetailCreateVM, OrderDetailCreateDto>();
            CreateMap<AdminOrderDetailUpdateVM, OrderDetailUpdateDto>();




            //PurchaseOrderController
            CreateMap<PurchaseOrderDto,AdminPurchaseOrderVM>();
            CreateMap<PurchaseOrderListDto, AdminPurchaseOrderListVM>();
            CreateMap<PurchaseOrderDetailsDto, AdminPurchaseOrderDetailsVM>();
            CreateMap<AdminPurchaseOrderCreateVM, PurchaseOrderCreateDto>();
            CreateMap<AdminPurchaseOrderUpdateVM, PurchaseOrderUpdateDto>();

            

                 



        }
    }
}





































































































































































































































































































































































































































































































































































































































































































































































































































































