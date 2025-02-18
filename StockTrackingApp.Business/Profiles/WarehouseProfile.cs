
using StockTrackingApp.Dtos.Warehouses;

namespace StockTrackingApp.Business.Profiles
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<WarehouseCreateDto, Warehouse>();
            CreateMap<Warehouse, WarehouseDetailsDto>();
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<Warehouse, WarehouseListDto>();
          
            CreateMap<WarehouseUpdateDto, Warehouse>();
        }
    }
}
