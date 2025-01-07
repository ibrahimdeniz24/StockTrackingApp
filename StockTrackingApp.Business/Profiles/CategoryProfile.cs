
using StockTrackingApp.Dtos.Categories;

namespace StockTrackingApp.Business.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryDetailsDto>();
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
