

using StockTrackingApp.Dtos.ProductSuppliers;

namespace StockTrackingApp.Business.Profiles
{
    public class ProductSupplierProfile :Profile
    {
        public ProductSupplierProfile()
        {
            CreateMap<ProductSupplier,ProductSupplierCreateDto>();
            CreateMap<ProductSupplier,ProductSupplierDto>();
            CreateMap<ProductSupplier,ProductSupplierListDto>();
            CreateMap<ProductSupplier,ProductSupplierUpdateDto>();
        }
    }
}
