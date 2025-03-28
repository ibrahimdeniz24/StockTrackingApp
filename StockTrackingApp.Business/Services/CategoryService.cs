
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Dtos.Products;
using System.Web.Mvc;

namespace StockTrackingApp.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDto categoryCreateDto)
        {
            var hasCategory = await _categoryRepository.AnyAsync(x => x.CategoryName.ToLower() == categoryCreateDto.CategoryName.ToLower());
            if (hasCategory)
            {
                return new ErrorDataResult<CategoryDto>(Messages.AddFailAlreadyExists);
            }

            var category = _mapper.Map<Category>(categoryCreateDto);

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(category), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return new ErrorResult(Messages.FoundFail);
                }
                await _categoryRepository.DeleteAsync(category);
                await _categoryRepository.SaveChangesAsync();
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<CategoryListDto>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return new SuccessDataResult<List<CategoryListDto>>(_mapper.Map<List<CategoryListDto>>(categories), Messages.ListedSuccess);

        }

        public async Task<List<SelectListItem>> GetAllCategoryAsSelectListAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            }).ToList();
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(category), Messages.FoundSuccess);
            }

            return new ErrorDataResult<CategoryDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<CategoryDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new ErrorDataResult<CategoryDetailsDto>(Messages.ListNotFound);
            }

            return new SuccessDataResult<CategoryDetailsDto>(_mapper.Map<CategoryDetailsDto>(category), Messages.ListedSuccess);
        }

        public async Task<PagedResult<CategoryListDto>> GetPagedOrdersAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = await _categoryRepository.GetAllAsync();

            var queryDto = _mapper.Map<List<CategoryListDto>>(query);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                queryDto = queryDto.Where(x => x.CategoryName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            var totalCount = queryDto.Count;

            var items = queryDto
                .OrderBy(x => x.CategoryName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<CategoryListDto>(items, totalCount);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            var product = await productRepository.GetAllAsync(x => x.CategoryId == categoryId);

            return product.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryUpdateDto.Id);
            if (category == null)
            {
                return new ErrorDataResult<CategoryDto>(Messages.FoundFail);
            }

            var updatedCategory = _mapper.Map(categoryUpdateDto, category);

            await _categoryRepository.UpdateAsync(updatedCategory);
            await _categoryRepository.SaveChangesAsync();

            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(updatedCategory), Messages.UpdateSuccess);
        }
    }
}
