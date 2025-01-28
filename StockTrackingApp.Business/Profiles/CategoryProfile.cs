
using StockTrackingApp.Dtos.Categories;

namespace StockTrackingApp.Business.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryDetailsDto>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
