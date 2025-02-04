using StockTrackingApp.Dtos.Categories;
using System.Web.Mvc;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id);
        Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDto categoryCreateDto);

        Task<IDataResult<List<CategoryListDto>>> GetAllAsync();
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<CategoryDetailsDto>> GetDetailsByIdAsync(Guid id);


        Task<List<SelectListItem>> GetAllCategoryAsSelectListAsync();
    }
}
