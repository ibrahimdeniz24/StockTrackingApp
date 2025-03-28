﻿
using StockTrackingApp.Dtos.Stocks;

namespace StockTrackingApp.Business.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockCreateDto, Stock>();
            CreateMap<StockUpdateDto, Stock>();
            CreateMap<Stock,StockDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<Stock,StockListDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name)) 
                .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.Product.SKU))  
                .ForMember(dest => dest.WareHouseName, opt => opt.MapFrom(src => src.Warehouse.Name))  
                .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => src.Product.ProductImage));  
            CreateMap<Stock,StockDetailsDto>()
                 .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.Product.SKU))
                .ForMember(dest => dest.WareHouseName, opt => opt.MapFrom(src => src.Warehouse.Name))
                .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => src.Product.ProductImage));

        }
    }
}
